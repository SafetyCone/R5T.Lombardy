using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;


namespace R5T.Lombardy
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="StringlyTypedPathOperator"/> implementation of <see cref="IStringlyTypedPathOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddDefaultStringlyTypedPathOperator(this IServiceCollection services)
        {
            services.AddSingleton<IStringlyTypedPathOperator, StringlyTypedPathOperator>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="StringlyTypedPathOperator"/> implementation of <see cref="IStringlyTypedPathOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddDefaultStringlyTypedPathOperator<TStringlyTypedPathOperator>(this IServiceCollection services)
            where TStringlyTypedPathOperator: IStringlyTypedPathOperator
        {
            services.AddDefaultStringlyTypedPathOperator();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="StringlyTypedPathOperator"/> implementation of <see cref="IStringlyTypedPathOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IStringlyTypedPathOperator> AddDefaultStringlyTypedPathOperatorAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<IStringlyTypedPathOperator>(() => services.AddDefaultStringlyTypedPathOperator());

            return serviceAction;
        }
    }
}
