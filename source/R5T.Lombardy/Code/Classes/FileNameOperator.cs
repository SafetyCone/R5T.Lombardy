using System;

using R5T.Lombardy.Base;


namespace R5T.Lombardy
{
    public class FileNameOperator : IFileNameOperator
    {
        public char DefaultFileNameSegmentSeparatorChar => FileName.DefaultFileNameSegmentSeparatorChar;
        public string DefaultFileNameSegmentSeparator => FileName.DefaultFileNameSegmentSeparator;


        public string GetFileExtension(string fileName)
        {
            var output = FileName.GetFileExtension(fileName);
            return output;
        }

        public string GetFileName(string fileNameWithoutExtension, string fileExtension)
        {
            var output = FileName.GetFileName(fileNameWithoutExtension, fileExtension);
            return output;
        }

        public string[] GetFileNameSegments(string fileName, string fileNameSegmentSeparator)
        {
            var output = FileName.GetFileNameSegments(fileName, fileNameSegmentSeparator);
            return output;
        }

        public string GetFileNameWithoutExtension(string fileName)
        {
            var output = FileName.GetFileNameWithoutExtension(fileName);
            return output;
        }

        public string GetGUIDedFileName()
        {
            var output = FileName.GetGUIDedFileName();
            return output;
        }

        public string GetGUIDedFileName(string fileExtension)
        {
            var output = FileName.GetGUIDedFileName();
            return output;
        }

        public string GetGUIDedFileNameWithoutExtension()
        {
            var output = FileName.GetGUIDedFileNameWithoutExtension();
            return output;
        }

        public string GetRandomFileName()
        {
            var output = FileName.GetRandomFileName();
            return output;
        }

        public string GetRandomFileName(string fileExtension)
        {
            var output = FileName.GetRandomFileName(fileExtension);
            return output;
        }

        public string GetRandomFileNameWithoutExtension()
        {
            var output = FileName.GetRandomFileNameWithoutExtension();
            return output;
        }
    }
}
