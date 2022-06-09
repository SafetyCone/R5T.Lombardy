using System;
using System.IO;

using R5T.Cherusci;
using R5T.Magyar;
using R5T.Magyar.Extensions;


namespace R5T.Lombardy
{
    public static class FileName
    {
        public const char DefaultFileNameSegmentSeparatorChar = '.';
        public const string DefaultFileNameSegmentSeparator = ".";


        public static string GetFileName(string fileNameWithoutExtension, string fileExtension)
        {
            var output = $"{fileNameWithoutExtension}{FileExtension.Separator}{fileExtension}";
            return output;
        }

        public static string[] GetFileNameSegments(string fileName, string fileNameSegmentSeparator)
        {
            var fileNameSegments = fileName.Split(fileNameSegmentSeparator.ToArray_FromSingle(), StringSplitOptions.None);
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

        public static string GetRandomFileNameWithoutExtension()
        {
            var randomFileNameWithRandomExtension = Path.GetRandomFileName();

            var randomFileNameWithoutExtension = randomFileNameWithRandomExtension.Replace(FileExtension.Separator, String.Empty);
            return randomFileNameWithoutExtension;
        }

        public static string GetRandomFileName()
        {
            var randomFileName = FileName.GetRandomFileName(FileExtensions.Temporary);
            return randomFileName;
        }

        public static string GetRandomFileName(string fileExtension)
        {
            var randomFileNameWithoutExtension = FileName.GetRandomFileNameWithoutExtension();

            var randomFileName = FileName.GetFileName(randomFileNameWithoutExtension, fileExtension);
            return randomFileName;
        }

        public static string GetGUIDedFileNameWithoutExtension()
        {
            var guidString = GuidHelper.GetNewGuidString();
            return guidString;
        }

        public static string GetGUIDedFileName()
        {
            var randomFileName = FileName.GetGUIDedFileName(FileExtensions.Temporary);
            return randomFileName;
        }

        public static string GetGUIDedFileName(string fileExtension)
        {
            var guidedFileNameWithoutExtension = FileName.GetRandomFileNameWithoutExtension();

            var randomFileName = FileName.GetFileName(guidedFileNameWithoutExtension, fileExtension);
            return randomFileName;
        }
    }
}
