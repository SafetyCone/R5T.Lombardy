using System;

using R5T.Magyar.Extensions.Object;


namespace R5T.Lombardy
{
    public static class FileName
    {
        public const char DefaultFileNameSegmentSeparatorChar = '.';

        public const string DefaultFileNameSegmentSeparator = ".";


        public static string[] GetFileNameSegments(string fileName, string fileNameSegmentSeparator)
        {
            var fileNameSegments = fileName.Split(fileNameSegmentSeparator.ToArray(), StringSplitOptions.None);
            return fileNameSegments;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            var lastSeparatorIndex = fileName.LastIndexOf(FileName.DefaultFileNameSegmentSeparatorChar);

            var fileNameWithoutExtension = fileName.Substring(0, lastSeparatorIndex);
            return fileNameWithoutExtension;
        }

        public static string GetFileExtension(string fileName)
        {
            var lastSeparatorIndex = fileName.LastIndexOf(FileName.DefaultFileNameSegmentSeparatorChar);

            var fileExtension = fileName.Substring(lastSeparatorIndex + 1);
            return fileExtension;
        }
    }
}
