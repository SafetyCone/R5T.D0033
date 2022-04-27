using System;

using R5T.T0009;

using IStringlyTypedUserNameProvider = R5T.D0032.IUserNameProvider;using R5T.T0064;


namespace R5T.D0033.Default
{[ServiceImplementationMarker]
    public class UserNameProvider : IUserNameProvider,IServiceImplementation
    {
        private IStringlyTypedUserNameProvider StringlyTypedUserNameProvider { get; }


        public UserNameProvider(IStringlyTypedUserNameProvider stringlyTypedUserNameProvider)
        {
            this.StringlyTypedUserNameProvider = stringlyTypedUserNameProvider;
        }

        public UserName GetUserName()
        {
            var userNameValue = this.StringlyTypedUserNameProvider.GetUserName();

            var userName = UserName.From(userNameValue);
            return userName;
        }
    }
}
