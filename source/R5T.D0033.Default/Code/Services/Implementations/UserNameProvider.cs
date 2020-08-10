using System;

using R5T.T0009;

using IStringlyTypedUserNameProvider = R5T.D0032.IUserNameProvider;


namespace R5T.D0033.Default
{
    public class UserNameProvider : IUserNameProvider
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
