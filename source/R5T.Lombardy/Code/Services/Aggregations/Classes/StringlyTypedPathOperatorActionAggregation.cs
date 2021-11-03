using System;

using R5T.T0063;


namespace R5T.Lombardy
{
    public class StringlyTypedPathOperatorActionAggregation : IStringlyTypedPathOperatorActionAggregation
    {
        public IServiceAction<IDirectoryNameOperator> DirectoryNameOperatorAction { get; set; }
        public IServiceAction<IDirectorySeparatorOperator> DirectorySeparatorOperatorAction { get; set; }
        public IServiceAction<IFileExtensionOperator> FileExtensionOperatorAction { get; set; }
        public IServiceAction<IFileNameOperator> FileNameOperatorAction { get; set; }
        public IServiceAction<IStringlyTypedPathOperator> StringlyTypedPathOperatorAction { get; set; }
    }
}
