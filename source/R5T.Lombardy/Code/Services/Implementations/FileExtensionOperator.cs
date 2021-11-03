using System;

using R5T.T0064;


namespace R5T.Lombardy
{
    [ServiceImplementationMarker]
    public class FileExtensionOperator : IFileExtensionOperator, IServiceImplementation
    {
        public char FileExtensionSeparatorChar => FileExtension.SeparatorChar;
        public string FileExtensionSeparator => FileExtension.Separator;
    }
}
