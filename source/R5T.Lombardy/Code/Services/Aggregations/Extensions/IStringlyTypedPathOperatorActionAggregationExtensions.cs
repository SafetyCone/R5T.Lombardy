using System;


namespace R5T.Lombardy
{
    public static class IStringlyTypedPathOperatorActionAggregationExtensions
    {
        public static T FillFrom<T>(this T aggregation,
            IStringlyTypedPathOperatorActionAggregation other)
            where T : IStringlyTypedPathOperatorActionAggregation
        {
            // Not sure why I need all this casting in this earlier version of .NET, but I don't need it later.
            (aggregation as IStringlyTypedPathOperatorActionAggregationIncrement).FillFrom(other as IStringlyTypedPathOperatorActionAggregationIncrement);

            return aggregation;
        }
    }
}
