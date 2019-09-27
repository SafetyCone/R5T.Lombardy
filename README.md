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


