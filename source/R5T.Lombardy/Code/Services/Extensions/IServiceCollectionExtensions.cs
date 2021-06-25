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

        /// <summary>
        /// Adds the <see cref="DirectoryNameOperator"/> implementation of <see cref="IDirectoryNameOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddDirectoryNameOperator(this IServiceCollection services)
        {
            services.AddSingleton<IDirectoryNameOperator, DirectoryNameOperator>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="DirectoryNameOperator"/> implementation of <see cref="IDirectoryNameOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IDirectoryNameOperator> AddDirectoryNameOperatorAction(this IServiceCollection services)
        {
            var serviceAction = ServiceAction.New<IDirectoryNameOperator>(() => services.AddDirectoryNameOperator());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="DirectorySeparatorOperator"/> implementation of <see cref="IDirectorySeparatorOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddDirectorySeparatorOperator(this IServiceCollection services)
        {
            services.AddSingleton<IDirectorySeparatorOperator, DirectorySeparatorOperator>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="DirectorySeparatorOperator"/> implementation of <see cref="IDirectorySeparatorOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IDirectorySeparatorOperator> AddDirectorySeparatorOperatorAction(this IServiceCollection services)
        {
            var serviceAction = ServiceAction.New<IDirectorySeparatorOperator>(() => services.AddDirectorySeparatorOperator());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="FileExtensionOperator"/> implementation of <see cref="IFileExtensionOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddFileExtensionOperator(this IServiceCollection services)
        {
            services.AddSingleton<IFileExtensionOperator, FileExtensionOperator>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="FileExtensionOperator"/> implementation of <see cref="IFileExtensionOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IFileExtensionOperator> AddFileExtensionOperatorAction(this IServiceCollection services)
        {
            var serviceAction = ServiceAction.New<IFileExtensionOperator>(() => services.AddFileExtensionOperator());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="FileNameOperator"/> implementation of <see cref="IFileNameOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddFileNameOperator(this IServiceCollection services)
        {
            services.AddSingleton<IFileNameOperator, FileNameOperator>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="FileNameOperator"/> implementation of <see cref="IFileNameOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IFileNameOperator> AddFileNameOperatorAction(this IServiceCollection services)
        {
            var serviceAction = ServiceAction.New<IFileNameOperator>(() => services.AddFileNameOperator());
            return serviceAction;
        }

        public static PathRelatedOperatorsAggregation01 AddPathRelatedOperatorsAction(this IServiceCollection services)
        {
            var directoryNameOperatorAction = services.AddDirectoryNameOperatorAction();
            var directorySeparatorOperatorAction = services.AddDirectorySeparatorOperatorAction();
            var fileExtensionOperatorAction = services.AddFileExtensionOperatorAction();
            var fileNameOperatorAction = services.AddFileNameOperatorAction();
            var stringlyTypedPathOperatorAction = services.AddDefaultStringlyTypedPathOperatorAction();

            return new PathRelatedOperatorsAggregation01
            {
                DirectoryNameOperatorAction = directoryNameOperatorAction,
                DirectorySeparatorOperatorAction = directorySeparatorOperatorAction,
                FileExtensionOperatorAction = fileExtensionOperatorAction,
                FileNameOperatorAction = fileNameOperatorAction,
                StringlyTypedPathOperatorAction = stringlyTypedPathOperatorAction,
            };
        }
    }
}
