using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using R5T.Magyar.Extensions;
using R5T.Magyar.Extensions.Object;

using R5T.Lombardy.Internals;


namespace R5T.Lombardy
{
    public static class StringlyTypedPath
    {
        public static bool ExistsFilePath(string filePath)
        {
            var output = File.Exists(filePath);
            return output;
        }

        public static bool ExistsDirectoryPath(string directoryPath)
        {
            var output = Directory.Exists(directoryPath);
            return output;
        }

        public static void DeleteFilePath(string filePath)
        {
            File.Delete(filePath);
        }

        public static void DeleteDirectoryPath(string directoryPath, bool recursive = true)
        {
            Directory.Delete(directoryPath, recursive);
        }

        public static char GetTerminatingChar(string path)
        {
            var output = path.Last(); // Not last-or-default. No returning the default char.
            return output;
        }

        public static char DetectDirectorySeparatorChar(string path)
        {
            var directorySeparator = StringlyTypedPath.DetectDirectorySeparator(path);

            var directorySeparatorChar = DirectorySeparator.StringToCharUnchecked(directorySeparator);
            return directorySeparatorChar;
        }

        /// <summary>
        /// In case of false, the output directory separator char has the <see cref="DirectorySeparator.DefaultChar"/> value.
        /// </summary>
        public static bool TryDetectDirectorySeparatorChar(string path, out char directorySeparatorChar)
        {
            var output = StringlyTypedPath.TryDetectDirectorySeparator(path, out var directorySeparator);

            directorySeparatorChar = DirectorySeparator.StringToCharUnchecked(directorySeparator);

            return output;
        }

        public static string DetectDirectorySeparator(string path)
        {
            var directorySeparator = DirectorySeparator.DetectDirectorySeparator(path);
            return directorySeparator;
        }

        /// <summary>
        /// In case of false, the output directory separator has the <see cref="DirectorySeparator.Default"/> value.
        /// </summary>
        public static bool TryDetectDirectorySeparator(string path, out string directorySeparator)
        {
            var output = DirectorySeparator.TryDetectDirectorySeparator(path, out directorySeparator);
            return output;
        }

        /// <summary>
        /// Determines if the provided path is a Windows path (contains the Windows directory separator, and if mixed, the Windows directory separator is dominant).
        /// If no directory separator is detected (for example, if the path is just a file name), then the path is assumed to be a Windows path.
        /// </summary>
        public static bool IsWindowsPathAssumeWindows(string path)
        {
            var output = DirectorySeparator.IsWindowsDirectorySeparatorDetectedAssumeWindows(path);
            return output;
        }

        public static bool IsWindowsPathStrict(string path)
        {
            var output = DirectorySeparator.IsWindowsDirectorySeparatorDetected(path);
            return output;
        }

        /// <summary>
        /// Determines if a path is a Windows path.
        /// Uses the <see cref="StringlyTypedPath.IsWindowsPathAssumeWindows(string)"/> function.
        /// </summary>
        public static bool IsWindowsPath(string path)
        {
            var output = StringlyTypedPath.IsWindowsPathAssumeWindows(path);
            return output;
        }

        /// <summary>
        /// Determines if the provided path is a non-Windows path (contains the non-Windows directory separator, and if mixed, the non-Windows directory separator is dominant).
        /// If no directory separator is detected (for example, if the path is just a file name), then the path is assumed to be a non-Windows path.
        /// </summary>
        public static bool IsNonWindowsPathAssumeNonWindows(string path)
        {
            var output = DirectorySeparator.IsNonWindowsDirectorySeparatorDetectedAssumeNonWindows(path);
            return output;
        }

        public static bool IsNonWindowsPathStrict(string path)
        {
            var output = DirectorySeparator.IsNonWindowsDirectorySeparatorDetected(path);
            return output;
        }

        /// <summary>
        /// Determines if a path is a Windows path.
        /// Uses the <see cref="StringlyTypedPath.IsNonWindowsPathAssumeNonWindows(string)"/> function.
        /// </summary>
        public static bool IsNonWindowsPath(string path)
        {
            var output = StringlyTypedPath.IsNonWindowsPathAssumeNonWindows(path);
            return output;
        }

        public static bool IsRootIndicatedPath(string path)
        {
            var pathBeginsWithRooting = Regex.IsMatch(path, Constants.RootIndicatedPathRegexPattern);
            return pathBeginsWithRooting;
        }

        public static bool IsNotRootIndicatedPath(string path)
        {
            var isRootIndicatedPath = StringlyTypedPath.IsRootIndicatedPath(path);

            var output = !isRootIndicatedPath;
            return output;
        }

        public static bool IsRelativeIndicatedPath(string path)
        {
            var output = StringlyTypedPath.IsNotRootIndicatedPath(path);
            return output;
        }

        public static bool IsRootedPath(string path)
        {
            var output = StringlyTypedPath.IsRootIndicatedPath(path);
            return output;
        }

        public static bool IsAbsolutePath(string path)
        {
            var output = StringlyTypedPath.IsRootIndicatedPath(path);
            return output;
        }

        public static bool IsRelativePath(string path)
        {
            var output = StringlyTypedPath.IsNotRootIndicatedPath(path);
            return output;
        }

        public static bool IsDirectoryIndicatedPath(string path)
        {
            var terminatingCharacter = StringlyTypedPath.GetTerminatingChar(path);

            var isTerminatingCharacterDirectorySeparator = DirectorySeparator.IsDirectorySeparator(terminatingCharacter);
            return isTerminatingCharacterDirectorySeparator;
        }

        public static bool IsNotDirectoryIndicatedPath(string path)
        {
            var isDirectoryIndicated = StringlyTypedPath.IsDirectoryIndicatedPath(path);

            var output = !isDirectoryIndicated;
            return output;
        }

        public static bool IsFileIndicatedPath(string path)
        {
            var output = StringlyTypedPath.IsNotDirectoryIndicatedPath(path);
            return output;
        }

        /// <summary>
        /// A short-hand method for determines if the path is directory *indicated*.
        /// Does not check if path is actually the path of an existing directory.
        /// </summary>
        public static bool IsDirectoryPath(string path)
        {
            var output = StringlyTypedPath.IsDirectoryIndicatedPath(path);
            return output;
        }

        /// <summary>
        /// A short-hand method for determines if the path is file *indicated* (not directory indicated).
        /// Does not check if path is actually the path of an existing file.
        /// </summary>
        public static bool IsFilePath(string path)
        {
            var output = StringlyTypedPath.IsNotDirectoryIndicatedPath(path);
            return output;
        }

        public static bool IsExistingDirectory(string path)
        {
            var output = StringlyTypedPath.ExistsDirectoryPath(path);
            return output;
        }

        public static bool IsExistingFile(string path)
        {
            var output = StringlyTypedPath.ExistsFilePath(path);
            return output;
        }

        /// <summary>
        /// Tests whether a path actually corresponds to an existing directory in the file system.
        /// The only way to determine (at a string-level of abstraction) whether a path is actually a directory path is to ask the file system.
        /// </summary>
        public static bool IsDirectory(string path)
        {
            var output = StringlyTypedPath.ExistsDirectoryPath(path);
            return output;
        }

        /// <summary>
        /// Tests whether a path actually corresponds to an existing directory in the file system.
        /// The only way to determine (at a string-level of abstraction) whether a path is actually a file path is to ask the file system.
        /// </summary>
        public static bool IsFile(string path)
        {
            var output = StringlyTypedPath.ExistsFilePath(path);
            return output;
        }

        public static bool IsResolvedPath(string path)
        {
            var isUnresolvedPath = StringlyTypedPath.IsUnresolvedPath(path);

            var output = !isUnresolvedPath;
            return output;
        }

        public static bool IsUnresolvedPath(string path)
        {
            var pathSegments = StringlyTypedPath.GetPathSegments(path);

            foreach (var pathSegment in pathSegments)
            {
                var isRelativeDirectoryName = DirectoryName.IsRelativeDirectoryName(pathSegment);
                if(isRelativeDirectoryName)
                {
                    return true;
                }
            }

            return false;
        }

        public static void ValidateIsDirectoryIndicatedPath(string pathSegment)
        {
            var isDirectoryIndicatedPath = StringlyTypedPath.IsDirectoryIndicatedPath(pathSegment);
            if(!isDirectoryIndicatedPath)
            {
                var exception = StringlyTypedPath.GetPathNotDirectoryIndicatedException(pathSegment);
                throw exception;
            }
        }

        public static void ValidateIsDirectoryIndicatedPath(string pathSegment, string parameterName)
        {
            var isDirectoryIndicatedPath = StringlyTypedPath.IsDirectoryIndicatedPath(pathSegment);
            if (!isDirectoryIndicatedPath)
            {
                var exception = StringlyTypedPath.GetPathNotDirectoryIndicatedArgumentException(pathSegment, parameterName);
                throw exception;
            }
        }

        public static void ValidateNotDirectoryIndicatedPath(string pathSegment)
        {
            var isDirectoryIndicatedPath = StringlyTypedPath.IsDirectoryIndicatedPath(pathSegment); // Ok logic, should test for not, but leads to a !not situation.
            if (isDirectoryIndicatedPath)
            {
                var exception = StringlyTypedPath.GetPathIsDirectoryIndicatedException(pathSegment);
                throw exception;
            }
        }

        public static void ValidateNotDirectoryIndicatedPath(string pathSegment, string parameterName)
        {
            var isDirectoryIndicatedPath = StringlyTypedPath.IsDirectoryIndicatedPath(pathSegment); // Ok logic, should test for not, but leads to a !not situation.
            if (isDirectoryIndicatedPath)
            {
                var exception = StringlyTypedPath.GetPathIsDirectoryIndicatedArgumentException(pathSegment, parameterName);
                throw exception;
            }
        }

        public static void ValidateIsFileIndicatedPath(string pathSegment)
        {
            StringlyTypedPath.ValidateNotDirectoryIndicatedPath(pathSegment);
        }

        public static void ValidateIsFileIndicatedPath(string pathSegment, string parameterName)
        {
            StringlyTypedPath.ValidateNotDirectoryIndicatedPath(pathSegment, parameterName);
        }

        public static void ValidateIsRootIndicatedPath(string pathSegment)
        {
            var isRootIndicatedPath = StringlyTypedPath.IsRootIndicatedPath(pathSegment);
            if (!isRootIndicatedPath)
            {
                var exception = StringlyTypedPath.GetPathNotRootIndicatedException(pathSegment);
                throw exception;
            }
        }

        public static void ValidateIsRootIndicatedPath(string pathSegment, string parameterName)
        {
            var isRootIndicatedPath = StringlyTypedPath.IsRootIndicatedPath(pathSegment);
            if (!isRootIndicatedPath)
            {
                var exception = StringlyTypedPath.GetPathNotRootIndicatedArgumentException(pathSegment, parameterName);
                throw exception;
            }
        }

        public static void ValidateNotRootIndicatedPath(string pathSegment)
        {
            var isRootIndicatedPath = StringlyTypedPath.IsRootIndicatedPath(pathSegment); // Ok logic, should test for not, but leads to a !not situation.
            if (isRootIndicatedPath)
            {
                var exception = StringlyTypedPath.GetPathIsRootIndicatedException(pathSegment);
                throw exception;
            }
        }

        public static void ValidateNotRootIndicatedPath(string pathSegment, string parameterName)
        {
            var isRootIndicatedPath = StringlyTypedPath.IsRootIndicatedPath(pathSegment); // Ok logic, should test for not, but leads to a !not situation.
            if (isRootIndicatedPath)
            {
                var exception = StringlyTypedPath.GetPathIsRootIndicatedArgumentException(pathSegment, parameterName);
                throw exception;
            }
        }

        /// <summary>
        /// Ensures that the provided path uses the specified directory separator.
        /// UNCHECKED: No check is done to validate that the specified directory separator is a valid directory separator. If an invalid directory separator is provided, the output path will have all instances of the invalid directory separator replaced with the Windows directory separator.
        /// </summary>
        public static string EnsureDirectorySeparatorUnchecked(string path, string directorySeparator)
        {
            var alternateDirectorySeparator = DirectorySeparator.GetAlternateDirectorySeparatorUnchecked(directorySeparator);

            var output = path.Replace(alternateDirectorySeparator, directorySeparator);
            return output;
        }

        /// <summary>
        /// Ensures that the provided path uses the specified directory separator.
        /// The directory separator must be a valid directory separator.
        /// </summary>
        public static string EnsureDirectorySeparatorChecked(string path, string directorySeparator)
        {
            DirectorySeparator.Validate(directorySeparator);

            var output = StringlyTypedPath.EnsureDirectorySeparatorUnchecked(path, directorySeparator);
            return output;
        }

        /// <summary>
        /// Ensures that the provided path uses the specified directory separator.
        /// Uses the <see cref="StringlyTypedPath.EnsureDirectorySeparatorChecked(string, string)"/> as the default implementation.
        /// </summary>
        public static string EnsureDirectorySeparator(string path, string directorySeparator)
        {
            var output = StringlyTypedPath.EnsureDirectorySeparatorChecked(path, directorySeparator);
            return output;
        }

        public static string EnsureWindowsDirectorySeparator(string path)
        {
            var output = StringlyTypedPath.EnsureDirectorySeparator(path, DirectorySeparator.Windows);
            return output;
        }

        public static string EnsureNonWindowsDirectorySeparator(string path)
        {
            var output = StringlyTypedPath.EnsureDirectorySeparator(path, DirectorySeparator.NonWindows);
            return output;
        }

        public static string EnsureWindowsPath(string path)
        {
            var output = StringlyTypedPath.EnsureWindowsDirectorySeparator(path);
            return output;
        }

        public static string EnsureNonWindowsPath(string path)
        {
            var output = StringlyTypedPath.EnsureNonWindowsDirectorySeparator(path);
            return output;
        }

        public static string EnsureRootIndicatedPath(string path, string directorySeparator)
        {
            DirectorySeparator.Validate(directorySeparator);

            var isRootIndicatedPath = StringlyTypedPath.IsRootIndicatedPath(path);
            if(!isRootIndicatedPath)
            {
                var output = StringlyTypedPath.MakePathRootIndicatedUnchecked(path, directorySeparator);
                return output;
            }

            return path;
        }

        public static string EnsureRootIndicatedPath(string path)
        {
            var isRootIndicatedPath = StringlyTypedPath.IsRootIndicatedPath(path);
            if (!isRootIndicatedPath)
            {
                var directorySeparator = DirectorySeparator.DetectDirectorySeparatorOrDefault(path);

                var output = StringlyTypedPath.MakePathRootIndicatedUnchecked(path, directorySeparator);
                return output;
            }

            return path;
        }

        public static string EnsureNotRootIndicatedPath(string path)
        {
            var isRootIndicatedPath = StringlyTypedPath.IsRootIndicatedPath(path);
            if (isRootIndicatedPath)
            {
                var directorySeparator = DirectorySeparator.DetectDirectorySeparator(path); // Will succeed since the path IS root indicated, and thus HAS a directory separator somewhere.

                var firstDirectorySeparatorPosition = path.IndexOf(directorySeparator);

                var output = path.Substring(firstDirectorySeparatorPosition + 1);
                return output;
            }

            return path;
        }

        public static string EnsureRelativeIndicatedPath(string path)
        {
            var output = StringlyTypedPath.EnsureNotRootIndicatedPath(path);
            return output;
        }

        public static string EnsureRootedPath(string path)
        {
            var output = StringlyTypedPath.EnsureRootIndicatedPath(path);
            return output;
        }

        public static string EnsureAbsolutePath(string path)
        {
            var output = StringlyTypedPath.EnsureRootIndicatedPath(path);
            return output;
        }

        public static string EnsureRelativePath(string path)
        {
            var output = StringlyTypedPath.EnsureNotRootIndicatedPath(path);
            return output;
        }

        public static string EnsureRootedPathIsRootIndicated(string rootedPath, string directorySeparator)
        {
            var output = StringlyTypedPath.EnsureRootIndicatedPath(rootedPath, directorySeparator);
            return output;
        }

        public static string EnsureRootedPathIsRootIndicated(string rootedPath)
        {
            var output = StringlyTypedPath.EnsureRootIndicatedPath(rootedPath);
            return output;
        }

        public static string EnsureRelativePathIsNotRootIndicated(string relativePath)
        {
            var output = StringlyTypedPath.EnsureNotRootIndicatedPath(relativePath);
            return output;
        }

        /// <summary>
        /// UNCHECKED: does not validate the directory separator.
        /// </summary>
        public static string MakePathRootIndicatedUnchecked(string path, string directorySeparator)
        {
            var output = path.Prefix(directorySeparator);
            return output;
        }

        /// <summary>
        /// Checked: the directory separator is validated, but the path is not.
        /// </summary>
        /// <summary>
        /// UNCHECKED: does not validate the directory separator.
        /// </summary>
        public static string MakePathRootIndicatedChecked(string path, string directorySeparator)
        {
            var output = path.Prefix(directorySeparator);
            return output;
        }

        /// <summary>
        /// Uses the <see cref="StringlyTypedPath.MakePathRootIndicatedChecked(string, string)"/>.
        /// </summary>
        public static string MakePathRootIndicated(string path, string directorySeparator)
        {
            DirectorySeparator.Validate(directorySeparator);

            var output = StringlyTypedPath.MakePathRootIndicatedUnchecked(path, directorySeparator);
            return output;
        }

        public static string EnsureDirectoryIndicatedPath(string path, string directorySeparator)
        {
            DirectorySeparator.Validate(directorySeparator);

            var isDirectoryIndicatedPath = StringlyTypedPath.IsDirectoryIndicatedPath(path);
            if(!isDirectoryIndicatedPath)
            {
                var output = StringlyTypedPath.MakePathDirectoryIndicatedUnchecked(path, directorySeparator);
                return output;
            }

            return path;
        }

        public static string EnsureDirectoryIndicatedPath(string path)
        {
            var isDirectoryIndicatedPath = StringlyTypedPath.IsDirectoryIndicatedPath(path);
            if (!isDirectoryIndicatedPath)
            {
                var directorySeparator = DirectorySeparator.DetectDirectorySeparator(path);

                var output = StringlyTypedPath.MakePathDirectoryIndicatedUnchecked(path, directorySeparator);
                return output;
            }

            return path;
        }

        public static string EnsureNotDirectoryIndicatedPath(string path)
        {
            var isDirectoryIndicatedPath = StringlyTypedPath.IsDirectoryIndicatedPath(path);
            if (isDirectoryIndicatedPath)
            {
                var output = path.ExceptLast();
                return output;
            }

            return path;
        }

        public static string EnsureFileIndicatedPath(string path)
        {
            var output = StringlyTypedPath.EnsureNotDirectoryIndicatedPath(path);
            return output;
        }

        public static string EnsureDirectoryPathIsDirectoryIndicated(string directoryPath, string directorySeparator)
        {
            var output = StringlyTypedPath.EnsureDirectoryIndicatedPath(directoryPath, directorySeparator);
            return output;
        }

        public static string EnsureDirectoryPathIsDirectoryIndicated(string directoryPath)
        {
            var output = StringlyTypedPath.EnsureDirectoryIndicatedPath(directoryPath);
            return output;
        }

        public static string EnsureFilePathIsNotDirectoryIndicated(string filePath)
        {
            var output = StringlyTypedPath.EnsureNotDirectoryIndicatedPath(filePath);
            return output;
        }

        /// <summary>
        /// UNCHECKED: the directory separator is not validated.
        /// </summary>
        public static string MakePathDirectoryIndicatedUnchecked(string path, string directorySeparator)
        {
            var output = path.Suffix(directorySeparator);
            return output;
        }

        /// <summary>
        /// Checked: the directory separator is checked to be a valid directory separator. The path is not checked.
        /// </summary>
        public static string MakePathDirectoryIndicatedChecked(string path, string directorySeparator)
        {
            DirectorySeparator.Validate(directorySeparator);

            var output = StringlyTypedPath.MakePathDirectoryIndicatedUnchecked(path, directorySeparator);
            return output;
        }

        /// <summary>
        /// Uses the <see cref="StringlyTypedPath.MakePathDirectoryIndicatedChecked(string, string)"/> function.
        /// </summary>
        public static string MakePathDirectoryIndicated(string path, string directorySeparator)
        {
            var output = StringlyTypedPath.MakePathDirectoryIndicatedChecked(path, directorySeparator);
            return output;
        }

        public static string EnsureResolvedPath(string path)
        {
            var isResolvedPath = StringlyTypedPath.IsResolvedPath(path);
            if(!isResolvedPath)
            {
                var resolvedPath = StringlyTypedPath.ResolvePath(path);
                return resolvedPath;
            }

            return path;
        }    

        public static string GetRelativePath(string sourcePath, string destinationPath)
        {
            var sourceIsFilePath = StringlyTypedPath.IsFilePath(sourcePath);
            var destinationIsFilePath = StringlyTypedPath.IsFilePath(sourcePath);

            string relativePath;
            if (sourceIsFilePath)
            {
                if (destinationIsFilePath)
                {
                    relativePath = StringlyTypedPath.GetRelativePathFileToFile(sourcePath, destinationPath);
                }
                else
                {
                    relativePath = StringlyTypedPath.GetRelativePathFileToDirectory(sourcePath, destinationPath);
                }
            }
            else
            {
                if (destinationIsFilePath)
                {
                    relativePath = StringlyTypedPath.GetRelativePathDirectoryToFile(sourcePath, destinationPath);
                }
                else
                {
                    relativePath = StringlyTypedPath.GetRelativePathDirectoryToDirectory(sourcePath, destinationPath);
                }
            }

            return relativePath;
        }

        public static string GetRelativePathFileToFile(string sourceFilePath, string destinationFilePath)
        {
            var relativePath = StringlyTypedPathInternals.GetRelativePathOutputWindowsIfWindows(sourceFilePath, destinationFilePath);

            // If the source file is the same as the destination file (empty relative path), do not perform any adjustment of the relative path.
            if (relativePath == String.Empty)
            {
                return relativePath;
            }

            var adjustedRelativePath = StringlyTypedPathInternals.AdjustRelativePathForFileSource(sourceFilePath, relativePath);
            return adjustedRelativePath;
        }

        public static string GetRelativePathFileToDirectory(string sourceFilePath, string destinationDirectoryPath)
        {
            // The Uri.MakeRelativeUri() method requires directory paths to be directory-indicated, else the path is assumed to be a file path. This only matters for the source path.
            var directoryIndicatedDestinationDirectoryPath = StringlyTypedPath.EnsureDirectoryPathIsDirectoryIndicated(destinationDirectoryPath);

            var relativePath = StringlyTypedPathInternals.GetRelativePathOutputWindowsIfWindows(sourceFilePath, destinationDirectoryPath);
            return relativePath;
        }

        public static string GetRelativePathDirectoryToFile(string sourceDirectoryPath, string destinationFilePath)
        {
            // The Uri.MakeRelativeUri() method requires directory paths to be directory-indicated, else the path is assumed to be a file path. This only matters for the source path.
            var directoryIndicatedSourceDirectoryPath = StringlyTypedPath.EnsureDirectoryPathIsDirectoryIndicated(sourceDirectoryPath);

            var relativePath = StringlyTypedPathInternals.GetRelativePathOutputWindowsIfWindows(directoryIndicatedSourceDirectoryPath, destinationFilePath);
            return relativePath;
        }

        public static string GetRelativePathDirectoryToDirectory(string sourceDirectoryPath, string destinationDirectoryPath)
        {
            // The Uri.MakeRelativeUri() method requires directory paths to be directory-indicated, else the path is assumed to be a file path. This only matters for the source path.
            var directoryIndicatedSourceDirectoryPath = StringlyTypedPath.EnsureDirectoryPathIsDirectoryIndicated(sourceDirectoryPath);
            var directoryIndicatedDestinationDirectoryPath = StringlyTypedPath.EnsureDirectoryPathIsDirectoryIndicated(destinationDirectoryPath);

            var relativePath = StringlyTypedPathInternals.GetRelativePathOutputWindowsIfWindows(directoryIndicatedSourceDirectoryPath, directoryIndicatedDestinationDirectoryPath);
            return relativePath;
        }

        public static string ResolvePath(string unresolvedPath)
        {
            var resolvedPath = StringlyTypedPathInternals.ResolvePathUsingUriLocalPath(unresolvedPath);
            return resolvedPath;
        }

        /// <summary>
        /// Combines a directory indicated path segment with another path segment.
        /// UNCHECKED: The directory indicated path segment is not checked to be actually directory indicated. The path segment is not checked to be not-root indicated.
        /// This is simple concatenation.
        /// </summary>
        public static string CombineDirectoryIndicatedUnchecked(string directoryIndicatedPathSegment1, string pathSegment2)
        {
            var output = directoryIndicatedPathSegment1 + pathSegment2;
            return output;
        }

        /// <summary>
        /// Checked: The directory indicated path segment is checked to be actually directory indicated. The path segment is checked to be not-root indicated.
        /// </summary>
        public static string CombineDirectoryIndicatedChecked(string directoryIndicatedPathSegment1, string pathSegment2)
        {
            StringlyTypedPath.ValidateIsDirectoryIndicatedPath(directoryIndicatedPathSegment1, nameof(directoryIndicatedPathSegment1));
            StringlyTypedPath.ValidateNotRootIndicatedPath(pathSegment2, nameof(pathSegment2));

            var output = StringlyTypedPath.CombineDirectoryIndicatedUnchecked(directoryIndicatedPathSegment1, pathSegment2);
            return output;
        }

        /// <summary>
        /// Ensures that the directory indicated path segment is directory indicated, and that the path segment is not root indicated.
        /// </summary>
        public static string CombineDirectoryIndicatedEnsured(string directoryIndicatedPathSegment1, string pathSegment2)
        {
            var ensuredDirectoryIndicatedPathSegment = StringlyTypedPath.EnsureDirectoryIndicatedPath(directoryIndicatedPathSegment1);
            var nonRootedPathSegement = StringlyTypedPath.EnsureNotRootIndicatedPath(pathSegment2);

            var output = StringlyTypedPath.CombineDirectoryIndicatedUnchecked(ensuredDirectoryIndicatedPathSegment, nonRootedPathSegement);
            return output;
        }

        /// <summary>
        /// Combines a directory indicated path segment with a second path segment.
        /// Uses the <see cref="StringlyTypedPath.CombineDirectoryIndicatedEnsured(string, string)"/> function.
        /// </summary>
        public static string CombineDirectoryIndicated(string directoryIndicatedPathSegment1, string pathSegment2)
        {
            var output = StringlyTypedPath.CombineDirectoryIndicatedEnsured(directoryIndicatedPathSegment1, pathSegment2);
            return output;
        }

        /// <summary>
        /// Combines path parts into a single path part using the provided directory separator.
        /// Literally just string concatentation of the inputs.
        /// All inputs are unchecked, and the resulting path part may be unresolved.
        /// UNCHECKED:
        /// * The directory separator is not checked to be a valid directory separator.
        /// * The first path segment is not checked to be not-directory indicated.
        /// * The second path segment is not checked to be not-root indicated.
        /// </summary>
        /// <param name="directorySeparator">The directory separator to use in combining paths. This value is not checked to be one of the valid directory separators.</param>
        /// <param name="pathSegment1">The first path part. This path part is not checked to be non-directory indicated. Multiple consecutive directory separator may result.</param>
        /// <param name="pathSegment2">The second path part. This path part is not checked to be non root-indicated. Multiple consecutive directory separator may result.</param>
        public static string CombineUnresolvedUnchecked(string directorySeparator, string pathSegment1, string pathSegment2)
        {
            var output = $"{pathSegment1}{directorySeparator}{pathSegment2}";
            return output;
        }

        /// <summary>
        /// Combines path parts into a single path part using the provided directory separator.
        /// All input arguments are checked, but invalid inputs are not manipulated to ensure correctness, and instead exceptions are thrown.
        /// Checked:
        /// * The directory separator is checked to be a valid directory separator.
        /// * The first path segment is checked to be not-directory indicated.
        /// * The second path segment is checked to be not-root indicated.
        /// </summary>
        /// <param name="directorySeparator">The directory separator to use in combining paths. This value is checked to be one of the valid directory separators, and an exception is thrown if not.</param>
        /// <param name="pathSegment1">The first path part. This path part is checked to be non-directory indicated, and an exception is thrown if not.</param>
        /// <param name="pathSegment2">The second path part. This path part is checked to be non root-indicated, and an exception is thrown if not.</param>
        public static string CombineUnresolvedChecked(string directorySeparator, string pathSegment1, string pathSegment2)
        {
            DirectorySeparator.Validate(directorySeparator);

            StringlyTypedPath.ValidateNotDirectoryIndicatedPath(pathSegment1, nameof(pathSegment1));
            StringlyTypedPath.ValidateNotRootIndicatedPath(pathSegment2, nameof(pathSegment2));

            var output = StringlyTypedPath.CombineUnresolvedUnchecked(directorySeparator, pathSegment1, pathSegment2);
            return output;
        }

        public static string CombineUnresolvedEnsured(string directorySeparator, string pathSegment1, string pathSegment2)
        {
            DirectorySeparator.Validate(directorySeparator);

            var notDirectoryIndicatedPath = StringlyTypedPath.EnsureNotDirectoryIndicatedPath(pathSegment1);
            var notRootIndicatedPath = StringlyTypedPath.EnsureNotRootIndicatedPath(pathSegment2);

            var output = StringlyTypedPath.CombineUnresolvedUnchecked(directorySeparator, notDirectoryIndicatedPath, notRootIndicatedPath);
            return output;
        }

        public static string CombineTwoUnresolved(string directorySeparator, string pathSegment1, string pathSegment2)
        {
            var output = StringlyTypedPath.CombineUnresolvedEnsured(directorySeparator, pathSegment1, pathSegment2);
            return output;
        }

        public static string CombineUnresolved(string directorySeparator, params string[] pathSegments)
        {
            DirectorySeparator.Validate(directorySeparator);

            var nSegments = pathSegments.Length;
            var ensuredSegments = pathSegments.Copy();

            // Ensure that all segments (except the last) are not directory indicated.
            for (int iSegment = 0; iSegment < nSegments - 1; iSegment++)
            {
                var pathSegment = ensuredSegments[iSegment];
                var ensuredNotDirectoryIndicated = StringlyTypedPath.EnsureNotDirectoryIndicatedPath(pathSegment);
                ensuredSegments[iSegment] = ensuredNotDirectoryIndicated;
            }

            // Ensure that all segments (after the first) are not root indicated.
            for (int iSegment = 1; iSegment < nSegments; iSegment++)
            {
                var pathSegment = ensuredSegments[iSegment];
                var trimmedPathSegment = StringlyTypedPath.EnsureNotRootIndicatedPath(pathSegment);
                ensuredSegments[iSegment] = trimmedPathSegment;
            }

            // Ensure all segments use the specified directory separator.
            for (int iSegment = 0; iSegment < nSegments; iSegment++)
            {
                var pathSegment = ensuredSegments[iSegment];
                var replacedPathSegment = StringlyTypedPath.EnsureDirectorySeparatorUnchecked(pathSegment, directorySeparator);
                ensuredSegments[iSegment] = replacedPathSegment;
            }

            // Join all segments using the specified directory separator.
            var output = String.Join(directorySeparator, ensuredSegments);
            return output;
        }

        public static string CombineTwo(string directorySeparator, string pathSegment1, string pathSegment2)
        {
            var unresolvedPath = StringlyTypedPath.CombineTwoUnresolved(directorySeparator, pathSegment1, pathSegment2);

            var output = StringlyTypedPath.ResolvePath(unresolvedPath);
            return output;
        }

        public static string CombineUsingDirectorySeparator(string directorySeparator, params string[] pathSegments)
        {
            var unresolvedCombinedPathSegment = StringlyTypedPath.CombineUnresolved(directorySeparator, pathSegments);

            var combinedPathSegment = StringlyTypedPath.ResolvePath(unresolvedCombinedPathSegment);
            return combinedPathSegment;
        }

        public static string CombineTwo(string pathSegment1, string pathSegment2)
        {
            var directorySeparator = DirectorySeparator.DetectDirectorySeparatorOrDefault(pathSegment1, pathSegment2);

            var output = StringlyTypedPath.CombineTwo(directorySeparator, pathSegment1, pathSegment2);
            return output;
        }

        public static string Combine(params string[] pathSegments)
        {
            var directorySeparator = DirectorySeparator.DetectDirectorySeparatorOrDefault(pathSegments);

            var output = StringlyTypedPath.CombineUsingDirectorySeparator(directorySeparator, pathSegments);
            return output;
        }

        public static string Combine(string pathSegment1, string pathSegment2)
        {
            var directorySeparator = DirectorySeparator.DetectDirectorySeparatorOrDefault(pathSegment1, pathSegment2);

            var output = StringlyTypedPath.CombineTwo(directorySeparator, pathSegment1, pathSegment2);
            return output;
        }

        public static string CombineWindows(params string[] pathSegments)
        {
            var output = StringlyTypedPath.CombineUsingDirectorySeparator(DirectorySeparator.Windows, pathSegments);
            return output;
        }

        public static string CombineNonWindows(params string[] pathSegments)
        {
            var output = StringlyTypedPath.CombineUsingDirectorySeparator(DirectorySeparator.NonWindows, pathSegments);
            return output;
        }

        /// <summary>
        /// Combines a directory path with a file name using the specified directory separator to get a file path.
        /// UNCHECKED: the directory separator is not validated to be an actual directory separator. The directory path is not checked to be not-directory indicated. The file name is not checked to be not-root indicated.
        /// This is simple string concatenation.
        /// </summary>
        public static string GetFilePathUnchecked(string directoryPath, string fileName, string directorySeparator)
        {
            var output = StringlyTypedPath.CombineUnresolvedUnchecked(directorySeparator, directoryPath, fileName);
            return output;
        }

        /// <summary>
        /// Combines a directory path with a file name using the specified directory separator to get a file path.
        /// Checked:
        /// * The directory separator is validated to be an actual directory separator.
        /// * The directory path is checked to be not-directory indicated.
        /// * The file name is checked to be not-root indicated.
        /// </summary>
        public static string GetFilePathChecked(string directoryPath, string fileName, string directorySeparator)
        {
            DirectorySeparator.Validate(directorySeparator);

            StringlyTypedPath.ValidateNotDirectoryIndicatedPath(directoryPath, nameof(directoryPath));
            StringlyTypedPath.ValidateNotRootIndicatedPath(fileName, nameof(fileName));

            var output = StringlyTypedPath.GetFilePathUnchecked(directoryPath, fileName, directorySeparator);
            return output;
        }

        /// <summary>
        /// Combines a directory path with a file name using the specified directory separator to get a file path.
        /// Ensured:
        /// * The directory separator is validated to be an actual directory separator.
        /// * The directory path is ensured to be not-directory indicated.
        /// * The file name is ensured to be not-root indicated.
        /// </summary>
        public static string GetFilePathEnsured(string directoryPath, string fileName, string directorySeparator)
        {
            DirectorySeparator.Validate(directorySeparator);

            var ensuredDirectoryPath = StringlyTypedPath.EnsureNotDirectoryIndicatedPath(directoryPath);
            var ensuredFileName = StringlyTypedPath.EnsureNotRootIndicatedPath(fileName);

            var output = StringlyTypedPath.GetFilePathUnchecked(ensuredDirectoryPath, ensuredFileName, directorySeparator);
            return output;
        }

        /// <summary>
        /// Combines a directory path with a file name using the specified directory separator to get a file path.
        /// Uses the <see cref="StringlyTypedPath.GetFilePath(string, string, string)"/> function.
        /// </summary>
        public static string GetFilePath(string directoryPath, string fileName, string directorySeparator)
        {
            var output = StringlyTypedPath.GetFilePathEnsured(directoryPath, fileName, directorySeparator);
            return output;
        }

        /// <summary>
        /// Combines a directory path with a file name using the directory separator value detected in the directory path (or if none is detected then the <see cref="DirectorySeparator.Default"/> value) to get a file path.
        /// </summary>
        public static string GetFilePath(string directoryPath, string fileName)
        {
            var directorySeparator = DirectorySeparator.DetectDirectorySeparatorOrDefault(directoryPath);

            var output = StringlyTypedPath.GetFilePathEnsured(directoryPath, fileName, directorySeparator);
            return output;
        }

        /// <summary>
        /// Combines a directory path with a directory name using the specified directory separator to get a directory path.
        /// UNCHECKED:
        /// * The directory separator is not validated to be an actual directory separator.
        /// * The directory path is not validated to be not-directory indicated.
        /// * The directory name is not validated to be not-root indicated.
        /// This is simple string concatenation.
        /// </summary>
        public static string GetDirectoryPathUnchecked(string directoryPath, string directoryName, string directorySeparator)
        {
            var output = StringlyTypedPath.CombineUnresolvedUnchecked(directorySeparator, directoryPath, directoryName);
            return output;
        }

        /// <summary>
        /// Combines a directory path with a directory name using the specified directory separator to get a directory path.
        /// Checked:
        /// * The directory separator is validated to be an actual directory separator.
        /// * The directory path is validated to be not-directory indicated.
        /// * The directory name is validated to be not-root indicated.
        /// </summary>
        public static string GetDirectoryPathChecked(string directoryPath, string directoryName, string directorySeparator)
        {
            DirectorySeparator.Validate(directorySeparator);

            StringlyTypedPath.ValidateNotDirectoryIndicatedPath(directoryPath, nameof(directoryPath));
            StringlyTypedPath.ValidateNotRootIndicatedPath(directoryName, nameof(directoryName));

            var output = StringlyTypedPath.GetFilePathUnchecked(directoryPath, directoryName, directorySeparator);
            return output;
        }

        /// <summary>
        /// Combines a directory path with a directory name using the specified directory separator to get a directory path.
        /// Ensured:
        /// * The directory separator is validated to be an actual directory separator.
        /// * The directory path is ensured to be not-directory indicated.
        /// * The directory name is ensured to be not-root indicated.
        /// </summary>
        public static string GetDirectoryPathEnsured(string directoryPath, string directoryName, string directorySeparator)
        {
            DirectorySeparator.Validate(directorySeparator);

            var ensuredDirectoryPath = StringlyTypedPath.EnsureNotDirectoryIndicatedPath(directoryPath);
            var ensuredDirectoryNameName = StringlyTypedPath.EnsureNotRootIndicatedPath(directoryName);

            var output = StringlyTypedPath.GetFilePathUnchecked(ensuredDirectoryPath, ensuredDirectoryNameName, directorySeparator);
            return output;
        }

        /// <summary>
        /// Combines a directory path with a directory name using the specified directory separator to get a directory path.
        /// Uses the <see cref="StringlyTypedPath.GetDirectoryPathEnsured(string, string, string)"/> function.
        /// </summary>
        public static string GetDirectoryPath(string directoryPath, string directoryName, string directorySeparator)
        {
            var output = StringlyTypedPath.GetDirectoryPathEnsured(directoryPath, directoryName, directorySeparator);
            return output;
        }

        /// <summary>
        /// Combines a directory path with a directory name using the directory separator detected in the directory path (or if none is detected, then the <see cref="DirectorySeparator.Default"/> value) to get a directory path.
        /// </summary>
        public static string GetDirectoryPath(string directoryPath, string directoryName)
        {
            var directorySeparator = DirectorySeparator.DetectDirectorySeparatorOrDefault(directoryPath);

            var output = StringlyTypedPath.GetDirectoryPathEnsured(directoryPath, directoryName, directorySeparator);
            return output;
        }

        /// <summary>
        /// Gets the path segments of a path that are separated by the specified directory separator.
        /// UNCHECKED: the directory separator could be any string.
        /// </summary>
        public static string[] GetPathSegmentsUnchecked(string path, string directorySeparator)
        {
            var separators = directorySeparator.ToArray();

            var pathSegments = path.Split(separators, StringSplitOptions.None);
            return pathSegments;
        }

        /// <summary>
        /// Gets the path segments of a path that are separated by the specified directory separator.
        /// Checks that the provided directory separator is actually a valid directory separator. Does not check the path.
        /// </summary>
        public static string[] GetPathSegmentsChecked(string path, string directorySeparator)
        {
            DirectorySeparator.Validate(directorySeparator);

            var output = StringlyTypedPath.GetPathSegmentsUnchecked(path, directorySeparator);
            return output;
        }

        /// <summary>
        /// Gets the path segments of a path that are separated by the the specified directory separator.
        /// Default uses <see cref="StringlyTypedPath.GetPathSegmentsChecked(string, string)"/>.
        /// </summary>
        public static string[] GetPathSegments(string path, string directorySeparator)
        {
            var output = StringlyTypedPath.GetPathSegmentsChecked(path, directorySeparator);
            return output;
        }

        /// <summary>
        /// Gets the path segments of a path that are separated by any of the valid directory separators (will provide all path segments for mixed paths).
        /// Note: for directory indicated paths, the last token will be an empty string since the string split option to keep empty values is chosen.
        /// </summary>
        public static string[] GetPathSegments(string path)
        {
            var separators = DirectorySeparator.ValidDirectorySeparatorChars;

            var pathSegments = path.Split(separators, StringSplitOptions.None);
            return pathSegments;
        }

        public static string GetFileNamePathSegment(params string[] pathSegments)
        {
            var fileNamePathSegment = pathSegments.Last();
            return fileNamePathSegment;
        }

        public static string GetFileName(string filePath)
        {
            StringlyTypedPath.ValidateIsFileIndicatedPath(filePath);

            var pathSegments = StringlyTypedPath.GetPathSegments(filePath);

            var fileName = StringlyTypedPath.GetFileNamePathSegment(pathSegments);
            return fileName;
        }

        public static string GetFileNameWithoutExtension(string filePath)
        {
            var fileName = StringlyTypedPath.GetFileName(filePath);

            var fileNameWithoutExtension = FileName.GetFileNameWithoutExtension(fileName);
            return fileNameWithoutExtension;
        }

        public static string GetFileExtension(string filePath)
        {
            var fileName = StringlyTypedPath.GetFileName(filePath);

            var fileExtension = FileName.GetFileExtension(fileName);
            return fileExtension;
        }

        public static string GetDirectoryPathForFilePath(string filePath)
        {
            StringlyTypedPath.ValidateIsFileIndicatedPath(filePath);

            var pathSegments = StringlyTypedPath.GetPathSegments(filePath);

            var directoryPathSegments = pathSegments.ExceptLast().ToArray();

            var directorySeparator = DirectorySeparator.DetectDirectorySeparator(filePath);

            var directoryPath = StringlyTypedPath.CombineUsingDirectorySeparator(directorySeparator, directoryPathSegments);
            return directoryPath;
        }

        public static string GetDirectoryNameForFilePath(string filePath)
        {
            StringlyTypedPath.ValidateIsFileIndicatedPath(filePath);

            var pathSegments = StringlyTypedPath.GetPathSegments(filePath);

            var directoryName = pathSegments.SecondToLast();
            return directoryName;
        }

        public static string GetDirectoryNameForDirectoryPathChecked(string directoryPath)
        {
            StringlyTypedPath.ValidateIsDirectoryIndicatedPath(directoryPath);

            var pathSegments = StringlyTypedPath.GetPathSegments(directoryPath);

            var directoryName = pathSegments.SecondToLast(); // The last will be empty since we have ensured a terminating directory separator.
            return directoryName;
        }

        public static string GetDirectoryNameForDirectoryPathEnsured(string directoryPath)
        {
            var ensuredDirectoryPath = StringlyTypedPath.EnsureDirectoryPathIsDirectoryIndicated(directoryPath);

            var output = StringlyTypedPath.GetDirectoryNameForDirectoryPathChecked(ensuredDirectoryPath);
            return output;
        }

        /// <summary>
        /// Uses <see cref="StringlyTypedPath.GetDirectoryNameForDirectoryPathEnsured(string)"/> function.
        /// </summary>
        public static string GetDirectoryNameForDirectoryPath(string directoryPath)
        {
            var output = StringlyTypedPath.GetDirectoryNameForDirectoryPathEnsured(directoryPath);
            return output;
        }

        public static string GetParentDirectoryPathForDirectoryPathChecked(string directoryPath)
        {
            StringlyTypedPath.ValidateIsDirectoryIndicatedPath(directoryPath);

            var pathSegments = StringlyTypedPath.GetPathSegments(directoryPath);

            var parentDirectoryName = pathSegments.NthToLast(3); // The last will be a balnk
            return parentDirectoryName;
        }

        public static string GetParentDirectoryPathForDirectoryPathEnsured(string directoryPath)
        {
            var ensuredDirectoryPath = StringlyTypedPath.EnsureDirectoryPathIsDirectoryIndicated(directoryPath);

            var output = StringlyTypedPath.GetParentDirectoryPathForDirectoryPathChecked(ensuredDirectoryPath);
            return output;
        }

        /// <summary>
        /// Uses the <see cref="StringlyTypedPath.GetParentDirectoryPathForDirectoryPath(string)"/> is chosen.
        /// </summary>
        public static string GetParentDirectoryPathForDirectoryPath(string directoryPath)
        {
            var output = StringlyTypedPath.GetParentDirectoryPathForDirectoryPathEnsured(directoryPath);
            return output;
        }


        #region Exceptions

        public static string GetPathIsDirectoryIndicatedExceptionMessage(string path)
        {
            var message = $"Path is directory indicated: '{path}'.";
            return message;
        }

        public static Exception GetPathIsDirectoryIndicatedException(string path)
        {
            var message = StringlyTypedPath.GetPathIsDirectoryIndicatedExceptionMessage(path);

            var exception = new Exception(message);
            return exception;
        }

        public static ArgumentException GetPathIsDirectoryIndicatedArgumentException(string path, string parameterName)
        {
            var message = StringlyTypedPath.GetPathIsDirectoryIndicatedExceptionMessage(path);

            var exception = new ArgumentException(message, parameterName);
            return exception;
        }

        public static string GetPathNotDirectoryIndicatedExceptionMessage(string path)
        {
            var message = $"Path not directory indicated: '{path}'.";
            return message;
        }

        public static Exception GetPathNotDirectoryIndicatedException(string path)
        {
            var message = StringlyTypedPath.GetPathNotDirectoryIndicatedExceptionMessage(path);

            var exception = new Exception(message);
            return exception;
        }

        public static ArgumentException GetPathNotDirectoryIndicatedArgumentException(string path, string parameterName)
        {
            var message = StringlyTypedPath.GetPathNotDirectoryIndicatedExceptionMessage(path);

            var exception = new ArgumentException(message, parameterName);
            return exception;
        }

        public static string GetPathIsRootIndicatedExceptionMessage(string path)
        {
            var message = $"Path is root indicated: '{path}'.";
            return message;
        }

        public static Exception GetPathIsRootIndicatedException(string path)
        {
            var message = StringlyTypedPath.GetPathIsRootIndicatedExceptionMessage(path);

            var exception = new Exception(message);
            return exception;
        }

        public static ArgumentException GetPathIsRootIndicatedArgumentException(string path, string parameterName)
        {
            var message = StringlyTypedPath.GetPathIsRootIndicatedExceptionMessage(path);

            var exception = new ArgumentException(message, parameterName);
            return exception;
        }

        public static string GetPathNotRootIndicatedExceptionMessage(string path)
        {
            var message = $"Path not root indicated: '{path}'.";
            return message;
        }

        public static Exception GetPathNotRootIndicatedException(string path)
        {
            var message = StringlyTypedPath.GetPathNotRootIndicatedExceptionMessage(path);

            var exception = new Exception(message);
            return exception;
        }

        public static ArgumentException GetPathNotRootIndicatedArgumentException(string path, string parameterName)
        {
            var message = StringlyTypedPath.GetPathNotRootIndicatedExceptionMessage(path);

            var exception = new ArgumentException(message, parameterName);
            return exception;
        }

        #endregion
    }
}
