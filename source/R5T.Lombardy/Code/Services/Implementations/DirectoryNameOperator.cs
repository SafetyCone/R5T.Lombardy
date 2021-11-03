using System;

using R5T.T0064;


namespace R5T.Lombardy
{
    [ServiceImplementationMarker]
    public class DirectoryNameOperator : IDirectoryNameOperator, IServiceImplementation
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
