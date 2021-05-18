using System;

using R5T.Lombardy.Base;


namespace R5T.Lombardy
{
    public class FileExtensionOperator : IFileExtensionOperator
    {
        public char FileExtensionSeparatorChar => FileExtension.SeparatorChar;
        public string FileExtensionSeparator => FileExtension.Separator;
    }
}
