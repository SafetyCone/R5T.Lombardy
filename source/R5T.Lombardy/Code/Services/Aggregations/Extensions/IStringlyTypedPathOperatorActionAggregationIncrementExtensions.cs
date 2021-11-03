using System;


namespace R5T.Lombardy
{
    public static class IStringlyTypedPathOperatorActionAggregationIncrementExtensions
    {
        public static T FillFrom<T>(this T aggregation,
            IStringlyTypedPathOperatorActionAggregationIncrement other)
            where T : IStringlyTypedPathOperatorActionAggregationIncrement
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
