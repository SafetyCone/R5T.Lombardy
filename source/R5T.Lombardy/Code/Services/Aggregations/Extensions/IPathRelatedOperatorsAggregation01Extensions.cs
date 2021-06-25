using System;


namespace R5T.Lombardy
{
    public static class IPathRelatedOperatorsAggregation01Extensions
    {
        public static T FillFrom<T>(this T aggregation,
            IPathRelatedOperatorsAggregation01 other)
            where T : IPathRelatedOperatorsAggregation01
        {
            aggregation.DirectoryNameOperatorAction = other.DirectoryNameOperatorAction;
            aggregation.DirectorySeparatorOperatorAction = other.DirectorySeparatorOperatorAction;
            aggregation.FileExtensionOperatorAction = other.FileExtensionOperatorAction;
            aggregation.FileNameOperatorAction = other.FileNameOperatorAction;
            aggregation.StringlyTypedPathOperatorAction = other.StringlyTypedPathOperatorAction;

            return aggregation;
        }
    }
}
