using System;


namespace R5T.Lombardy
{
    public class StringlyTypedPathOperator : IStringlyTypedPathOperator
    {
        public bool ExistsFilePath(string filePath)
        {
            var output = StringlyTypedPath.ExistsFilePath(filePath);
            return output;
        }

        public bool ExistsDirectoryPath(string directoryPath)
        {
            var output = StringlyTypedPath.ExistsDirectoryPath(directoryPath);
            return output;
        }

        public void DeleteFilePath(string filePath)
        {
            StringlyTypedPath.DeleteFilePath(filePath);
        }

        public void DeleteDirectoryPath(string directoryPath, bool recursive = true)
        {
            StringlyTypedPath.DeleteDirectoryPath(directoryPath, recursive);
        }

        public char GetTerminatingChar(string path)
        {
            var output = StringlyTypedPath.GetTerminatingChar(path);
            return output;
        }

        public char DetectDirectorySeparatorChar(string path)
        {
            var output = StringlyTypedPath.DetectDirectorySeparatorChar(path);
            return output;
        }

        public bool TryDetectDirectorySeparatorChar(string path, out char directorySeparatorChar)
        {
            var output = StringlyTypedPath.TryDetectDirectorySeparatorChar(path, out directorySeparatorChar);
            return output;
        }

        public string DetectDirectorySeparator(string path)
        {
            var output = StringlyTypedPath.DetectDirectorySeparator(path);
            return output;
        }

        public bool TryDetectDirectorySeparator(string path, out string directorySeparator)
        {
            var output = StringlyTypedPath.TryDetectDirectorySeparator(path, out directorySeparator);
            return output;
        }

        // Classification.
        public bool IsWindowsPathAssumeWindows(string path)
        {
            var output = StringlyTypedPath.IsWindowsPathAssumeWindows(path);
            return output;
        }

        public bool IsWindowsPathStrict(string path)
        {
            var output = StringlyTypedPath.IsWindowsPathStrict(path);
            return output;
        }

        public bool IsWindowsPath(string path)
        {
            var output = StringlyTypedPath.IsWindowsPath(path);
            return output;
        }

        public bool IsNonWindowsPathAssumeNonWindows(string path)
        {
            var output = StringlyTypedPath.IsNonWindowsPathAssumeNonWindows(path);
            return output;
        }

        public bool IsNonWindowsPathStrict(string path)
        {
            var output = StringlyTypedPath.IsNonWindowsPathStrict(path);
            return output;
        }

        public bool IsNonWindowsPath(string path)
        {
            var output = StringlyTypedPath.IsNonWindowsPath(path);
            return output;
        }

        public bool IsRootIndicatedPath(string path)
        {
            var output = StringlyTypedPath.IsRootIndicatedPath(path);
            return output;
        }

        public bool IsNotRootIndicatedPath(string path)
        {
            var output = StringlyTypedPath.IsNotRootIndicatedPath(path);
            return output;
        }

        public bool IsRelativeIndicatedPath(string path)
        {
            var output = StringlyTypedPath.IsRelativeIndicatedPath(path);
            return output;
        }

        public bool IsRootedPath(string path)
        {
            var output = StringlyTypedPath.IsRootedPath(path);
            return output;
        }

        public bool IsAbsolutePath(string path)
        {
            var output = StringlyTypedPath.IsAbsolutePath(path);
            return output;
        }

        public bool IsRelativePath(string path)
        {
            var output = StringlyTypedPath.IsRelativePath(path);
            return output;
        }

        public bool IsDirectoryIndicatedPath(string path)
        {
            var output = StringlyTypedPath.IsDirectoryIndicatedPath(path);
            return output;
        }

        public bool IsNotDirectoryIndicatedPath(string path)
        {
            var output = StringlyTypedPath.IsNotDirectoryIndicatedPath(path);
            return output;
        }

        public bool IsFileIndicatedPath(string path)
        {
            var output = StringlyTypedPath.IsFileIndicatedPath(path);
            return output;
        }

        public bool IsDirectoryPath(string path)
        {
            var output = StringlyTypedPath.IsDirectoryPath(path);
            return output;
        }

        public bool IsFilePath(string path)
        {
            var output = StringlyTypedPath.IsFilePath(path);
            return output;
        }

        public bool IsExistingDirectory(string path)
        {
            var output = StringlyTypedPath.IsExistingDirectory(path);
            return output;
        }

        public bool IsExistingFile(string path)
        {
            var output = StringlyTypedPath.IsExistingFile(path);
            return output;
        }

        public bool IsDirectory(string path)
        {
            var output = StringlyTypedPath.IsDirectory(path);
            return output;
        }

        public bool IsFile(string path)
        {
            var output = StringlyTypedPath.IsFile(path);
            return output;
        }

        public bool IsResolvedPath(string path)
        {
            var output = StringlyTypedPath.IsResolvedPath(path);
            return output;
        }

        public bool IsUnresolvedPath(string path)
        {
            var output = StringlyTypedPath.IsUnresolvedPath(path);
            return output;
        }

        // Validate.
        public void ValidateIsDirectoryIndicatedPath(string pathSegment)
        {
            StringlyTypedPath.ValidateIsDirectoryIndicatedPath(pathSegment);
        }

        public void ValidateIsDirectoryIndicatedPath(string pathSegment, string parameterName)
        {
            StringlyTypedPath.ValidateIsDirectoryIndicatedPath(pathSegment, parameterName);
        }

        public void ValidateNotDirectoryIndicatedPath(string pathSegment)
        {
            StringlyTypedPath.ValidateNotDirectoryIndicatedPath(pathSegment);
        }

        public void ValidateNotDirectoryIndicatedPath(string pathSegment, string parameterName)
        {
            StringlyTypedPath.ValidateNotDirectoryIndicatedPath(pathSegment, parameterName);
        }

        public void ValidateIsFileIndicatedPath(string pathSegment)
        {
            StringlyTypedPath.ValidateIsFileIndicatedPath(pathSegment);
        }

        public void ValidateIsFileIndicatedPath(string pathSegment, string parameterName)
        {
            StringlyTypedPath.ValidateIsFileIndicatedPath(pathSegment, parameterName);
        }

        public void ValidateIsRootIndicatedPath(string pathSegment)
        {
            StringlyTypedPath.ValidateIsRootIndicatedPath(pathSegment);
        }

        public void ValidateIsRootIndicatedPath(string pathSegment, string parameterName)
        {
            StringlyTypedPath.ValidateIsRootIndicatedPath(pathSegment, parameterName);
        }

        public void ValidateNotRootIndicatedPath(string pathSegment)
        {
            StringlyTypedPath.ValidateNotRootIndicatedPath(pathSegment);
        }

        public void ValidateNotRootIndicatedPath(string pathSegment, string parameterName)
        {
            StringlyTypedPath.ValidateNotRootIndicatedPath(pathSegment, parameterName);
        }

        // Ensure.
        public string EnsureDirectorySeparatorUnchecked(string path, string directorySeparator)
        {
            var output = StringlyTypedPath.EnsureDirectorySeparatorUnchecked(path, directorySeparator);
            return output;
        }

        public string EnsureDirectorySeparatorChecked(string path, string directorySeparator)
        {
            var output = StringlyTypedPath.EnsureDirectorySeparatorChecked(path, directorySeparator);
            return output;
        }

        public string EnsureDirectorySeparator(string path, string directorySeparator)
        {
            var output = StringlyTypedPath.EnsureDirectorySeparator(path, directorySeparator);
            return output;
        }

        public string EnsureWindowsDirectorySeparator(string path)
        {
            var output = StringlyTypedPath.EnsureWindowsDirectorySeparator(path);
            return output;
        }

        public string EnsureNonWindowsDirectorySeparator(string path)
        {
            var output = StringlyTypedPath.EnsureNonWindowsDirectorySeparator(path);
            return output;
        }

        public string EnsureWindowsPath(string path)
        {
            var output = StringlyTypedPath.EnsureWindowsPath(path);
            return output;
        }

        public string EnsureNonWindowsPath(string path)
        {
            var output = StringlyTypedPath.EnsureNonWindowsPath(path);
            return output;
        }

        public string EnsureRootIndicatedPath(string path, string directorySeparator)
        {
            var output = StringlyTypedPath.EnsureRootIndicatedPath(path, directorySeparator);
            return output;
        }

        public string EnsureRootIndicatedPath(string path)
        {
            var output = StringlyTypedPath.EnsureRootIndicatedPath(path);
            return output;
        }

        public string EnsureNotRootIndicatedPath(string path)
        {
            var output = StringlyTypedPath.EnsureNotRootIndicatedPath(path);
            return output;
        }

        public string EnsureRelativeIndicatedPath(string path)
        {
            var output = StringlyTypedPath.EnsureRelativeIndicatedPath(path);
            return output;
        }

        public string EnsureRootedPath(string path)
        {
            var output = StringlyTypedPath.EnsureRootedPath(path);
            return output;
        }

        public string EnsureAbsolutePath(string path)
        {
            var output = StringlyTypedPath.EnsureAbsolutePath(path);
            return output;
        }

        public string EnsureRelativePath(string path)
        {
            var output = StringlyTypedPath.EnsureRelativePath(path);
            return output;
        }

        public string EnsureRootedPathIsRootIndicated(string rootedPath, string directorySeparator)
        {
            var output = StringlyTypedPath.EnsureRootedPathIsRootIndicated(rootedPath, directorySeparator);
            return output;
        }

        public string EnsureRootedPathIsRootIndicated(string rootedPath)
        {
            var output = StringlyTypedPath.EnsureRootedPathIsRootIndicated(rootedPath);
            return output;
        }

        public string EnsureRelativePathIsNotRootIndicated(string relativePath)
        {
            var output = StringlyTypedPath.EnsureRelativePathIsNotRootIndicated(relativePath);
            return output;
        }

        public string MakePathRootIndicatedUnchecked(string path, string directorySeparator)
        {
            var output = StringlyTypedPath.MakePathRootIndicatedUnchecked(path, directorySeparator);
            return output;
        }

        public string MakePathRootIndicatedChecked(string path, string directorySeparator)
        {
            var output = StringlyTypedPath.MakePathRootIndicatedChecked(path, directorySeparator);
            return output;
        }

        public string MakePathRootIndicated(string path, string directorySeparator)
        {
            var output = StringlyTypedPath.MakePathRootIndicated(path, directorySeparator);
            return output;
        }

        public string EnsureDirectoryIndicatedPath(string path, string directorySeparator)
        {
            var output = StringlyTypedPath.EnsureDirectoryIndicatedPath(path, directorySeparator);
            return output;
        }

        public string EnsureDirectoryIndicatedPath(string path)
        {
            var output = StringlyTypedPath.EnsureDirectoryIndicatedPath(path);
            return output;
        }

        public string EnsureNotDirectoryIndicatedPath(string path)
        {
            var output = StringlyTypedPath.EnsureNotDirectoryIndicatedPath(path);
            return output;
        }

        public string EnsureFileIndicatedPath(string path)
        {
            var output = StringlyTypedPath.EnsureFileIndicatedPath(path);
            return output;
        }

        public string EnsureDirectoryPathIsDirectoryIndicated(string directoryPath, string directorySeparator)
        {
            var output = StringlyTypedPath.EnsureDirectoryPathIsDirectoryIndicated(directoryPath, directorySeparator);
            return output;
        }

        public string EnsureDirectoryPathIsDirectoryIndicated(string directoryPath)
        {
            var output = StringlyTypedPath.EnsureDirectoryPathIsDirectoryIndicated(directoryPath);
            return output;
        }

        public string EnsureFilePathIsNotDirectoryIndicated(string filePath)
        {
            var output = StringlyTypedPath.EnsureFilePathIsNotDirectoryIndicated(filePath);
            return output;
        }

        public string MakePathDirectoryIndicatedUnchecked(string path, string directorySeparator)
        {
            var output = StringlyTypedPath.MakePathDirectoryIndicatedUnchecked(path, directorySeparator);
            return output;
        }

        public string MakePathDirectoryIndicatedChecked(string path, string directorySeparator)
        {
            var output = StringlyTypedPath.MakePathDirectoryIndicatedChecked(path, directorySeparator);
            return output;
        }

        public string MakePathDirectoryIndicated(string path, string directorySeparator)
        {
            var output = StringlyTypedPath.MakePathDirectoryIndicated(path, directorySeparator);
            return output;
        }

        public string EnsureResolvedPath(string path)
        {
            var output = StringlyTypedPath.EnsureResolvedPath(path);
            return output;
        }

        // Relative paths.
        public string GetRelativePath(string sourcePath, string destinationPath)
        {
            var output = StringlyTypedPath.GetRelativePath(sourcePath, destinationPath);
            return output;
        }

        public string GetRelativePathFileToFile(string sourceFilePath, string destinationFilePath)
        {
            var output = StringlyTypedPath.GetRelativePathFileToFile(sourceFilePath, destinationFilePath);
            return output;
        }

        public string GetRelativePathFileToDirectory(string sourceFilePath, string destinationDirectoryPath)
        {
            var output = StringlyTypedPath.GetRelativePathFileToDirectory(sourceFilePath, destinationDirectoryPath);
            return output;
        }

        public string GetRelativePathDirectoryToFile(string sourceDirectoryPath, string destinationFilePath)
        {
            var output = StringlyTypedPath.GetRelativePathDirectoryToFile(sourceDirectoryPath, destinationFilePath);
            return output;
        }

        public string GetRelativePathDirectoryToDirectory(string sourceDirectoryPath, string destinationDirectoryPath)
        {
            var output = StringlyTypedPath.GetRelativePathDirectoryToDirectory(sourceDirectoryPath, destinationDirectoryPath);
            return output;
        }

        // Resolution.
        public string ResolvePath(string unresolvedPath)
        {
            var output = StringlyTypedPath.ResolvePath(unresolvedPath);
            return output;
        }

        // Combine.
        public string CombineDirectoryIndicatedUnchecked(string directoryIndicatedPathSegment1, string pathSegment2)
        {
            var output = StringlyTypedPath.CombineDirectoryIndicatedUnchecked(directoryIndicatedPathSegment1, pathSegment2);
            return output;
        }

        public string CombineDirectoryIndicatedChecked(string directoryIndicatedPathSegment1, string pathSegment2)
        {
            var output = StringlyTypedPath.CombineDirectoryIndicatedChecked(directoryIndicatedPathSegment1, pathSegment2);
            return output;
        }

        public string CombineDirectoryIndicatedEnsured(string directoryIndicatedPathSegment1, string pathSegment2)
        {
            var output = StringlyTypedPath.CombineDirectoryIndicatedEnsured(directoryIndicatedPathSegment1, pathSegment2);
            return output;
        }

        public string CombineDirectoryIndicated(string directoryIndicatedPathSegment1, string pathSegment2)
        {
            var output = StringlyTypedPath.CombineDirectoryIndicated(directoryIndicatedPathSegment1, pathSegment2);
            return output;
        }

        public string CombineUnresolvedUnchecked(string directorySeparator, string pathSegment1, string pathSegment2)
        {
            var output = StringlyTypedPath.CombineUnresolvedUnchecked(directorySeparator, pathSegment1, pathSegment2);
            return output;
        }

        public string CombineUnresolvedChecked(string directorySeparator, string pathSegment1, string pathSegment2)
        {
            var output = StringlyTypedPath.CombineUnresolvedChecked(directorySeparator, pathSegment1, pathSegment1);
            return output;
        }

        public string CombineUnresolvedEnsured(string directorySeparator, string pathSegment1, string pathSegment2)
        {
            var output = StringlyTypedPath.CombineUnresolvedEnsured(directorySeparator, pathSegment1, pathSegment2);
            return output;
        }

        public string CombineTwoUnresolved(string directorySeparator, string pathSegment1, string pathSegment2)
        {
            var output = StringlyTypedPath.CombineTwoUnresolved(directorySeparator, pathSegment1, pathSegment2);
            return output;
        }

        public string CombineUnresolved(string directorySeparator, params string[] pathSegments)
        {
            var output = StringlyTypedPath.CombineUnresolved(directorySeparator, pathSegments);
            return output;
        }

        public string CombineTwo(string directorySeparator, string pathSegment1, string pathSegment2)
        {
            var output = StringlyTypedPath.CombineTwo(directorySeparator, pathSegment1, pathSegment2);
            return output;
        }

        public string CombineUsingDirectorySeparator(string directorySeparator, params string[] pathSegments)
        {
            var output = StringlyTypedPath.CombineUsingDirectorySeparator(directorySeparator, pathSegments);
            return output;
        }

        public string CombineTwo(string pathSegment1, string pathSegment2)
        {
            var output = StringlyTypedPath.CombineTwo(pathSegment1, pathSegment2);
            return output;
        }

        public string Combine(params string[] pathSegments)
        {
            var output = StringlyTypedPath.Combine(pathSegments);
            return output;
        }

        public string Combine(string pathSegment1, string pathSegment2)
        {
            var output = StringlyTypedPath.Combine(pathSegment1, pathSegment2);
            return output;
        }

        public string CombineWindows(params string[] pathSegments)
        {
            var output = StringlyTypedPath.CombineWindows(pathSegments);
            return output;
        }

        public string CombineNonWindows(params string[] pathSegments)
        {
            var output = StringlyTypedPath.CombineNonWindows(pathSegments);
            return output;
        }

        public string GetFilePathUnchecked(string directoryPath, string fileName, string directorySeparator)
        {
            var output = StringlyTypedPath.GetFilePathUnchecked(directoryPath, fileName, directorySeparator);
            return output;
        }

        public string GetFilePathChecked(string directoryPath, string fileName, string directorySeparator)
        {
            var output = StringlyTypedPath.GetFilePathChecked(directoryPath, fileName, directorySeparator);
            return output;
        }

        public string GetFilePathEnsured(string directoryPath, string fileName, string directorySeparator)
        {
            var output = StringlyTypedPath.GetFilePathEnsured(directoryPath, fileName, directorySeparator);
            return output;
        }

        public string GetFilePath(string directoryPath, string fileName, string directorySeparator)
        {
            var output = StringlyTypedPath.GetFilePathEnsured(directoryPath, fileName, directorySeparator);
            return output;
        }

        public string GetFilePath(string directoryPath, string fileName)
        {
            var output = StringlyTypedPath.GetFilePath(directoryPath, fileName);
            return output;
        }

        public string GetDirectoryPathUnchecked(string directoryPath, string directoryName, string directorySeparator)
        {
            var output = StringlyTypedPath.GetDirectoryPathUnchecked(directoryPath, directoryName, directorySeparator);
            return output;
        }

        public string GetDirectoryPathChecked(string directoryPath, string directoryName, string directorySeparator)
        {
            var output = StringlyTypedPath.GetDirectoryPathChecked(directoryPath, directoryName, directorySeparator);
            return output;
        }

        public string GetDirectoryPathEnsured(string directoryPath, string directoryName, string directorySeparator)
        {
            var output = StringlyTypedPath.GetDirectoryPathEnsured(directoryPath, directoryName, directorySeparator);
            return output;
        }

        public string GetDirectoryPath(string directoryPath, string directoryName, string directorySeparator)
        {
            var output = StringlyTypedPath.GetDirectoryPath(directoryPath, directoryName, directorySeparator);
            return output;
        }

        public string GetDirectoryPath(string directoryPath, string directoryName)
        {
            var output = StringlyTypedPath.GetDirectoryPath(directoryPath, directoryName);
            return output;
        }

        // Separate.
        public string[] GetPathSegmentsUnchecked(string path, string directorySeparator)
        {
            var output = StringlyTypedPath.GetPathSegmentsUnchecked(path, directorySeparator);
            return output;
        }

        public string[] GetPathSegmentsChecked(string path, string directorySeparator)
        {
            var output = StringlyTypedPath.GetPathSegmentsChecked(path, directorySeparator);
            return output;
        }

        public string[] GetPathSegments(string path, string directorySeparator)
        {
            var output = StringlyTypedPath.GetPathSegments(path, directorySeparator);
            return output;
        }

        public string[] GetPathParts(string path)
        {
            var output = StringlyTypedPath.GetPathSegments(path);
            return output;
        }

        public string GetFileNamePathSegment(params string[] pathSegments)
        {
            var output = StringlyTypedPath.GetFileNamePathSegment(pathSegments);
            return output;
        }

        public string GetFileName(string filePath)
        {
            var output = StringlyTypedPath.GetFileName(filePath);
            return output;
        }

        public string GetFileNameWithoutExtension(string filePath)
        {
            var output = StringlyTypedPath.GetFileNameWithoutExtension(filePath);
            return output;
        }

        public string GetFileExtension(string filePath)
        {
            var output = StringlyTypedPath.GetFileExtension(filePath);
            return output;
        }

        public string GetDirectoryPathForFilePath(string filePath)
        {
            var output = StringlyTypedPath.GetDirectoryPathForFilePath(filePath);
            return output;
        }

        public string GetDirectoryNameForFilePath(string filePath)
        {
            var output = StringlyTypedPath.GetDirectoryNameForFilePath(filePath);
            return output;
        }

        public string GetDirectoryNameForDirectoryPathChecked(string directoryPath)
        {
            var output = StringlyTypedPath.GetDirectoryNameForDirectoryPathChecked(directoryPath);
            return output;
        }

        public string GetDirectoryNameForDirectoryPathEnsured(string directoryPath)
        {
            var output = StringlyTypedPath.GetDirectoryNameForDirectoryPathEnsured(directoryPath);
            return output;
        }

        public string GetDirectoryNameForDirectoryPath(string directoryPath)
        {
            var output = StringlyTypedPath.GetDirectoryNameForDirectoryPath(directoryPath);
            return output;
        }

        public string GetParentDirectoryPathForDirectoryPathChecked(string directoryPath)
        {
            var output = StringlyTypedPath.GetParentDirectoryPathForDirectoryPathChecked(directoryPath);
            return output;
        }

        public string GetParentDirectoryPathForDirectoryPathEnsured(string directoryPath)
        {
            var output = StringlyTypedPath.GetParentDirectoryPathForDirectoryPathEnsured(directoryPath);
            return output;
        }

        public string GetParentDirectoryPathForDirectoryPath(string directoryPath)
        {
            var output = StringlyTypedPath.GetParentDirectoryPathForDirectoryPath(directoryPath);
            return output;
        }


        #region Exceptions

        public string GetPathIsDirectoryIndicatedExceptionMessage(string path)
        {
            var output = StringlyTypedPath.GetPathIsDirectoryIndicatedExceptionMessage(path);
            return output;
        }

        public Exception GetPathIsDirectoryIndicatedException(string path)
        {
            var output = StringlyTypedPath.GetPathIsDirectoryIndicatedException(path);
            return output;
        }

        public ArgumentException GetPathIsDirectoryIndicatedArgumentException(string path, string parameterName)
        {
            var output = StringlyTypedPath.GetPathIsDirectoryIndicatedArgumentException(path, parameterName);
            return output;
        }

        public string GetPathNotDirectoryIndicatedExceptionMessage(string path)
        {
            var output = StringlyTypedPath.GetPathNotDirectoryIndicatedExceptionMessage(path);
            return output;
        }
        
        public Exception GetPathNotDirectoryIndicatedException(string path)
        {
            var output = StringlyTypedPath.GetPathNotDirectoryIndicatedException(path);
            return output;
        }

        public ArgumentException GetPathNotDirectoryIndicatedArgumentException(string path, string parameterName)
        {
            var output = StringlyTypedPath.GetPathNotDirectoryIndicatedArgumentException(path, parameterName);
            return output;
        }

        public string GetPathIsRootIndicatedExceptionMessage(string path)
        {
            var output = StringlyTypedPath.GetPathIsRootIndicatedExceptionMessage(path);
            return output;
        }

        public Exception GetPathIsRootIndicatedException(string path)
        {
            var output = StringlyTypedPath.GetPathIsRootIndicatedException(path);
            return output;
        }

        public ArgumentException GetPathIsRootIndicatedArgumentException(string path, string parameterName)
        {
            var output = StringlyTypedPath.GetPathIsRootIndicatedArgumentException(path, parameterName);
            return output;
        }

        public string GetPathNotRootIndicatedExceptionMessage(string path)
        {
            var output = StringlyTypedPath.GetPathNotRootIndicatedExceptionMessage(path);
            return output;
        }

        public Exception GetPathNotRootIndicatedException(string path)
        {
            var output = StringlyTypedPath.GetPathNotRootIndicatedException(path);
            return output;
        }

        public ArgumentException GetPathNotRootIndicatedArgumentException(string path, string parameterName)
        {
            var output = StringlyTypedPath.GetPathNotRootIndicatedArgumentException(path, parameterName);
            return output;
        }

        #endregion
    }
}
