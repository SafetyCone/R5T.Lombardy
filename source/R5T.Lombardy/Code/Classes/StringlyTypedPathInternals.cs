using System;

using R5T.Magyar.Extensions;


namespace R5T.Lombardy.Internals
{
    public static class StringlyTypedPathInternals
    {
        public static string GetRelativePathUriToUri(string sourcePath, string destinationPath)
        {
            var sourceUri = new Uri(new Uri("file://"), sourcePath);
            var destinationUri = new Uri(new Uri("file://"), destinationPath);

            var relativeUri = sourceUri.MakeRelativeUri(destinationUri);

            var relativePath = Uri.UnescapeDataString(relativeUri.ToString());
            return relativePath;
        }

        public static string GetRelativePathOutputWindowsIfWindows(string sourcePath, string destinationPath)
        {
            var relativePath = StringlyTypedPathInternals.GetRelativePathUriToUri(sourcePath, destinationPath);

            // The Uri.MakeRelativeUri() method outputs the non-Windows directory separator. If the input source path was a Windows path, output a Windows path.
            var isWindowsPath = StringlyTypedPath.IsWindowsPathStrict(sourcePath);
            if (isWindowsPath)
            {
                var ensuredWindowsRelativePath = StringlyTypedPath.EnsureWindowsDirectorySeparator(relativePath);
                return ensuredWindowsRelativePath;
            }

            return relativePath;
        }

        public static string AdjustRelativePathForFileSource(string sourceFilePath, string relativePath)
        {
            // The Uri.MakeRelativeUri() output requires special handling for file path sources since it always produces paths relative to the most derived directory path (which for a file path is the path of the directory containing the file).
            var directorySeparator = DirectorySeparator.NonWindows; // The Uri.MakeRelativeUri() method always produces paths using the non-Windows directory separator.
            var isWindowsPath = StringlyTypedPath.IsWindowsPathStrict(sourceFilePath);
            if (isWindowsPath)
            {
                directorySeparator = DirectorySeparator.Windows;
            }

            var prefix = $"{DirectoryName.ParentDirectoryName}{directorySeparator}";

            var prefixedRelativePath = relativePath.Prefix(prefix);
            return prefixedRelativePath;
        }

        public static string ResolvePathUsingUriLocalPath(string unresolvedPath)
        {
            try
            {
                var unresolvedUri = new Uri(new Uri("file://"), unresolvedPath);

                var resolvedPath = unresolvedUri.LocalPath;
                return resolvedPath;
            }
            catch (UriFormatException uriFormatException)
            {
                var message = $"Failed to resolve path: {unresolvedPath}";
                throw new ArgumentException(message, nameof(unresolvedPath), uriFormatException);
            }
        }
    }
}
