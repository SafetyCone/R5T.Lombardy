using System;

using R5T.Dacia;


namespace R5T.Lombardy
{
    public interface IPathRelatedOperatorsAggregation01
    {
        IServiceAction<IDirectoryNameOperator> DirectoryNameOperatorAction { get; set; }
        IServiceAction<IDirectorySeparatorOperator> DirectorySeparatorOperatorAction { get; set; }
        IServiceAction<IFileExtensionOperator> FileExtensionOperatorAction { get; set; }
        IServiceAction<IFileNameOperator> FileNameOperatorAction { get; set; }
        IServiceAction<IStringlyTypedPathOperator> StringlyTypedPathOperatorAction { get; set; }
    }
}
