using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0062;
using R5T.T0063;


namespace R5T.Lombardy
{
    public static class IServiceActionExtensions
    {
        public static IStringlyTypedPathOperatorActionAggregation AddStringlyTypedPathOperatorActions(this IServiceAction _)
        {
            var directoryNameOperatorAction = _.AddDirectoryNameOperatorAction();
            var directorySeparatorOperatorAction = _.AddDirectorySeparatorOperatorAction();
            var fileExtensionOperatorAction = _.AddFileExtensionOperatorAction();
            var fileNameOperatorAction = _.AddFileNameOperatorAction();
            var stringlyTypedPathOperatorAction = _.AddStringlyTypedPathOperatorAction();

            var output = new StringlyTypedPathOperatorActionAggregation
            {
                DirectoryNameOperatorAction = directoryNameOperatorAction,
                DirectorySeparatorOperatorAction = directorySeparatorOperatorAction,
                FileExtensionOperatorAction = fileExtensionOperatorAction,
                FileNameOperatorAction = fileNameOperatorAction,
                StringlyTypedPathOperatorAction = stringlyTypedPathOperatorAction,
            };

            return output;
        }

        /// <summary>
        /// Adds the <see cref="FileNameOperator"/> implementation of <see cref="IFileNameOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IFileNameOperator> AddFileNameOperatorAction(this IServiceAction _)
        {
            var serviceAction = _.New<IFileNameOperator>(services => services.AddFileNameOperator());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="FileExtensionOperator"/> implementation of <see cref="IFileExtensionOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IFileExtensionOperator> AddFileExtensionOperatorAction(this IServiceAction _)
        {
            var serviceAction = _.New<IFileExtensionOperator>(services => services.AddFileExtensionOperator());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="DirectorySeparatorOperator"/> implementation of <see cref="IDirectorySeparatorOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IDirectorySeparatorOperator> AddDirectorySeparatorOperatorAction(this IServiceAction _)
        {
            var serviceAction = _.New<IDirectorySeparatorOperator>(services => services.AddDirectorySeparatorOperator());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="DirectoryNameOperator"/> implementation of <see cref="IDirectoryNameOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IDirectoryNameOperator> AddDirectoryNameOperatorAction(this IServiceAction _)
        {
            var serviceAction = _.New<IDirectoryNameOperator>(services => services.AddDirectoryNameOperator());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="StringlyTypedPathOperator"/> implementation of <see cref="IStringlyTypedPathOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IStringlyTypedPathOperator> AddStringlyTypedPathOperatorAction(this IServiceAction _)
        {
            var serviceAction = _.New<IStringlyTypedPathOperator>(services => services.AddDefaultStringlyTypedPathOperator());

            return serviceAction;
        }
    }
}
