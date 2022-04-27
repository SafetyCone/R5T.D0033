using System;

using R5T.T0009;
using R5T.T0064;


namespace R5T.D0033
{
    [ServiceDefinitionMarker]
    public interface IUserNameProvider : IServiceDefinition
    {
        UserName GetUserName();
    }
}
