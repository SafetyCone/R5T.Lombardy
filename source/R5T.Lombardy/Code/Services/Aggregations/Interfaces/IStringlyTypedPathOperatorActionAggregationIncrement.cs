using System;

using R5T.T0063;


namespace R5T.Lombardy
{
    public interface IStringlyTypedPathOperatorActionAggregationIncrement
    {
        IServiceAction<IDirectoryNameOperator> DirectoryNameOperatorAction { get; set; }
        IServiceAction<IDirectorySeparatorOperator> DirectorySeparatorOperatorAction { get; set; }
        IServiceAction<IFileExtensionOperator> FileExtensionOperatorAction { get; set; }
        IServiceAction<IFileNameOperator> FileNameOperatorAction { get; set; }
        IServiceAction<IStringlyTypedPathOperator> StringlyTypedPathOperatorAction { get; set; }
    }
}
