using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;

using IStringlyTypedUserNameProvider = R5T.D0032.IUserNameProvider;


namespace R5T.D0033.Default
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="UserNameProvider"/> implementation of <see cref="IUserNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddUserNameProvider(this IServiceCollection services,
            IServiceAction<IStringlyTypedUserNameProvider> stringlyTypedUserNameProviderAction)
        {
            services
                .AddSingleton<IUserNameProvider, UserNameProvider>()
                .Run(stringlyTypedUserNameProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="UserNameProvider"/> implementation of <see cref="IUserNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IUserNameProvider> AddUserNameProviderAction(this IServiceCollection services,
            IServiceAction<IStringlyTypedUserNameProvider> stringlyTypedUserNameProviderAction)
        {
            var serviceAction = ServiceAction.New<IUserNameProvider>(() => services.AddUserNameProvider(
                stringlyTypedUserNameProviderAction));

            return serviceAction;
        }
    }
}
