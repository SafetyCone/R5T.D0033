using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;

using R5T.D0033.Default;

using IStringlyTypedUserNameProvider = R5T.D0032.IUserNameProvider;
using StringlyTypedIServiceCollectionExtensions = R5T.D0032.Default.IServiceCollectionExtensions;


namespace R5T.D0033.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="IUserNameProvider"/> service and dependencies.
        /// </summary>
        public static
            (
            IServiceAction<IUserNameProvider> Main,
            IServiceAction<IStringlyTypedUserNameProvider> stringlyTypedUserNameProviderAction
            )
        AddUserNameProviderAction(this IServiceCollection services)
        {
            var stringlyTypedUserNameProviderAction = StringlyTypedIServiceCollectionExtensions.AddUserNameProviderAction(services);

            var userNameProviderAction = services.AddUserNameProviderAction(
                stringlyTypedUserNameProviderAction);

            return
                (
                userNameProviderAction,
                stringlyTypedUserNameProviderAction
                );
        }

        /// <summary>
        /// Adds the <see cref="IUserNameProvider"/> service and dependencies.
        /// </summary>
        public static IServiceCollection AddUserNameProvider(this IServiceCollection services)
        {
            var userNameProviderAction = services.AddUserNameProviderAction();

            services.Run(userNameProviderAction.Main);

            return services;
        }
    }
}
