using System;
using System.IO;

using R5T.Magyar;


namespace R5T.Lombardy
{
    public static class DirectoryName
    {
        public const char DefaultDirectoryNameSegmentSeparatorChar = '.';
        public const string DefaultDirectoryNameSegmentSeparator = ".";

        public const string CurrentRelativeDirectoryName = ".";
        public const string ParentRelativeDirectoryName = "..";

        public static string[] RelativeDirectoryNames => new string[] { DirectoryName.CurrentRelativeDirectoryName, DirectoryName.ParentRelativeDirectoryName };


        public static bool IsRelativeDirectoryName(string directoryName)
        {
            var output = directoryName == DirectoryName.CurrentRelativeDirectoryName
                || directoryName == DirectoryName.ParentRelativeDirectoryName;

            return output;
        }

        public static string GetGUIDedDirectoryName()
        {
            var guidString = GuidHelper.GetNewGuidString();
            return guidString;
        }

        public static string GetRandomDirectoryName()
        {
            var randomFileNameWithRandomExtension = Path.GetRandomFileName();

            var randomDirectoryName = randomFileNameWithRandomExtension.Replace(FileExtension.Separator, String.Empty);
            return randomDirectoryName;
        }
    }
}
