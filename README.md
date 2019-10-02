# R5T.Lombardy
An implementation of, and test-fixture for, a stringly-typed file-system path operator.

# A Taxonomy of Paths
Paths are character strings composed of a root, and zero or more names separated by a directory separator. Paths are defined by:

1. How they start: with or without a directory separator?
2. How they end: with or without a directory separator?
3. Which directory separator: ('\\', back-slash) or ('/', slash)?
4. Contains relative directory names ('.', the current directory, or '..', the parent directory)?

Each of these options has two choices which correspond to:

1. How they start: is the path rooted (started with a directory separator), or relative (does not start with a directory separator)?
2. How they end: is the path a directory path (ends with a directory separator) or file path (ends without a directory separator)?
3. Which directory separator: is the path a Windows path ('\\', back-slash) or non-Windows path ('/', slash)?
4. Use of relative directory names ('.' or '..'): is the path resolved (contains no relative directory names) or unresolved (contains relative directory names).

Some of these options have default assumptions:

1. How they start: rooted. Rooted paths are "paths", relative paths are "relative paths".
2. How they end: directory paths end with a directory separator, file paths don't. While it is entirely possible for a directory path to not end with a directory separator (since directories are actually files), at the string-level of abstraction there is no way to distinguish whether a path that does not end with a directory separator is a file path or directory path. Also, while files generally have a file extension, it is entirely possible for a file to not have a file extension. Finally, while file paths almost never end with a directory separator, it's the file system that actually has final say over whether a path leads to a file or a directory. In this ambiguity, we stick to the assumption that directory paths end with a directory separator, file paths don't.
3. Which directory separator: Windows or non-Windows. There is no default assumption made about paths, with both path formats being equally valid.
4. Use of relative directory names: resolved. Resolved paths are "paths", unresolved paths are "unresolved paths". Everyone prefers to read resolved paths and only resolved paths can actually be used to identify a resouce. Thus, with an unresolved path work must be done to follow all relative directory names to get a final resolved path.

## Terminology

- Root-indicated: If a path starts with a directory separator, then it is root-indicated. The path may not be rooted, and is only root-*indicated*, since determining if a path is rooted requires extra work is required, and in some cases can only be determined from context.
- Absolute (rooted) path: An absolute (or rooted) path starts with a root. Note that only absolute paths can actually be used to locate file-system resources. All rooted paths are root-indicated, but not all root-indicated paths are rooted.
- Relative path: A relative path does not start with a root, and must be combined with a rooted path to actually locate a file-system resource. All relative paths are *not* root-indicated.
- Directory-indicated: If a path ends with a directory separator, then it is directory-indicated. The path may not actually be a directory path, since a file-path can in fact end with a directory separator and it's up to the file-system to actually determine if a path leads to a file or directory. Conversely, a non-directory indicated path may actually be a directory. In fact, most directory paths do *not* include the ending directory separator, again leaving it up to the file-system to actually determine if the path leads to a file or directory. Thus a path is only directory-*indicated* if it ends with a directory separator.
- File path: a path to a file. File paths generally have a file extension, but do not have to. File paths generally are not directory-indicated, but it's up to the file-system to actually determine if a path leads to a file or directory.
- Directory path: a path to a directory. Directores *are* files, but special files that contain pointers to other files. Directory paths are generally *not* root-indicated, which is weird. So it's up to the file-system to actually determine if a path leads to a file or directory.
- Windows or Non-Windows. Windows is special, in the difficult-child type of way. It uses a the opposite directory separator from everything else; back-slash ('\\') instead of slash ('/'). This, perversely, makes classifying paths easy: they are Windows or everything else. Thus Windows gets to the be the fundamental for directory separators, where all others operating systems use the non-Windows directory separator.
- Mixed: A path might contain both Windows and Non-Windows directory separators. In this case it is a mixed path.
- Dominant directory separator: In a mixed path, whichever directory separator is encountered first (is closer to the root of the path) is the dominant directory separator, and the dominant directory separator determines whether a mixed path is a Windows path or a Non-Windows path.
- Resolved and Unresolved: Paths can contain relative directory names, which are '.' for the current directory and ('..') for the parent directory. An unresolved path contains relative directory names. After work is done to *resolve* the unresolved path by following relative directory names and replacing them with the name of an actual directory, then the path is a resolved path. Note that only resolved paths can actually be used to locate file-system resources and all unresolved paths must first be resolved, either by code or the OS itself.
- Ensure: Given some boolean test, like `IsXXX()`, in case of failure ensure methods remedy the failure by manipulating the value so that it will pass the test. Because paths are relative simple constructs and generally their boolean tests are simple, remedying failure is usually simple and desireable from the perspective of robustness.
- Qualified: To guide clients towards the most useful and robust implementations of methods, these implementation methods get the default operation name without any *qualifying* suffixes (ex: "-Simple", "-Unresolved", "-Multiple" etc.).

# A Taxonomy of Path Operations
The species of path operations fall into several genuses:

- Combine: The fundamental path operation is combining multiple path segments into a single path segment.
- Separate: Second most important opertation is separating a single path segment into multiple path segments, or extracting a single part of path segment.
- Classify: Given a path, where does it fit into the taxonomy of paths? Frequently classification is implemented by an `Is()` method, as in `IsRootIndicatedPath()` or `IsWindowsPath()`.
- Ensure: For (nearly) every `Is()` method there is, an `Ensure()` method. Ensure methods call `Is()` methods, but in the case of failure, then manipulate the input to remedy the failure. Since paths are generally simple constructs, remedies for failures are usually simple fixes that are desirable for robustness. Examples: `EnsureIsRootIndicated()` or `EnsureWindowsPath()`.
- Resolve: Given an unresolved path, resolve the path.
- Detect: Given a path, determine some property of the path.

While there are a variety of path operations, these operations come in several different types:

- Unchecked: unchecked operations skip performing any validation checks on input arguments and go straight to performing an operation. Unchecked operations provide conceptual simplicity, allow non-standard uses, and are frequently the base versions of an operation called by more complicated versions of an operation. These unchecked operations are frequently used "internally" after inputs have been checked.

- Checked: checked operations perform validation checks on input arguments, but do not manipulate inputs to ensure the inputs pass those checks, instead opting to throw an exception. These checked operations allow conceptual clarity, or are the base implementations of operations which ensured versions of the operation call after performing validation and manipulations on input arguments.

- Ensured: path validation checks are generally simple enough that if input validation checks fail, the input can be manipulated so that is passes the validation check (for example, if a path is not directory indicated, an appropriate directory separator can be added to the end of the path). Ensured versions of an operation ensure their inputs have the correct form before performing an operation.

- Base (or default): one of the unchecked, checked, or ensured operations is chosen to be the default for each specific operation, depending on what is usually expected in a context. Generally, the ensured operation is the default. To guide clients towards methods implementing these most robust and useful versions of operations, the names of methods implementing the unchecked, checked, and ensured versions of an operation are qualified (suffixed) with "-Unchecked", "-Checked", or "-Ensured". The default method name is left unqualified. Thus the base, or default versions of an operation are more likely to be used since they have unqualified names.
 
# List of Path Operations

- Combine
- Get relative path
- Resolve path
- Get default directory separator
- Detect directory separator
- Validation of directory separator argument
- Exists
- Is
- Ensure
- Validation that string is a path. (Does not contain any invalid characters, is not too long.)


## Combine

- CombineUnchecked
- CombineSimple
- Combine


## Get default directory separator

- Get the default directory separator.
- Set the default directory separator.
- Get the default directory separator for the current machine environment.
- Get the alternate directory separator for the current machine environment.
- Given a directory separator, get the alternate directory separator.


## Detect directory separator

- ContainsWindowsDirectorySeparator
- ContainsNonWindowsDirectorySeparator
- HasMixedDirectorySeparators
- DetermineDominantDirectorySeparator
- IsWindowsPath
- IsNonWindowsPath


# Exceptions

There are several exceptions that communicate problems with path operation inputs.

All of these exceptions start as being of type ArgumentException, but can be given their own exception type if desired.

- InvalidDirectorySeparator
- WindowsDirectorySeparatorExpected
- NonWindowsDirectorySeparatorExpected
- UnableToDetectDirectorySeparator
- PathIsRootIndicated
- PathIsNotRootIndicated
- PathIsDirectoryIndicated
- PathIsNotDirectoryIndicated
- PathIsWindowsPath
- PathIsNonWindowsPath
- PathIsUnresolved
- PathIsResolved
