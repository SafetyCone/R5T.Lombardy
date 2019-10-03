using System;


namespace R5T.Lombardy
{
    public static class DirectoryName
    {
        public const char DefaultDirectoryNameSegmentSeparatorChar = '.';
        public const string DefaultDirectoryNameSegmentSeparator = ".";

        public const string CurrentDirectoryName = ".";
        public const string ParentDirectoryName = "..";

        public static string[] RelativeDirectoryNames => new string[] { DirectoryName.CurrentDirectoryName, DirectoryName.ParentDirectoryName };


        public static bool IsRelativeDirectoryName(string directoryName)
        {
            var output = directoryName == DirectoryName.CurrentDirectoryName
                || directoryName == DirectoryName.ParentDirectoryName;

            return output;
        }
    }
}
