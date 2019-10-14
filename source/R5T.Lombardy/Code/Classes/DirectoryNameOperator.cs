using System;

using R5T.Lombardy.Base;


namespace R5T.Lombardy
{
    public class DirectoryNameOperator : IDirectoryNameOperator
    {
        public char DefaultDirectoryNameSegmentSeparatorChar => DirectoryName.DefaultDirectoryNameSegmentSeparatorChar;
        public string DefaultDirectoryNameSegmentSeparator => DirectoryName.DefaultDirectoryNameSegmentSeparator;

        public string CurrentRelativeDirectoryName => DirectoryName.CurrentRelativeDirectoryName;
        public string ParentRelativeDirectoryName => DirectoryName.ParentRelativeDirectoryName;

        public string[] RelativeDirectoryNames => DirectoryName.RelativeDirectoryNames;


        public string GetGUIDedDirectoryName()
        {
            var output = DirectoryName.GetGUIDedDirectoryName();
            return output;
        }

        public string GetRandomDirectoryName()
        {
            var output = DirectoryName.GetRandomDirectoryName();
            return output;
        }

        public bool IsRelativeDirectoryName(string directoryName)
        {
            var output = DirectoryName.IsRelativeDirectoryName(directoryName);
            return output;
        }
    }
}
