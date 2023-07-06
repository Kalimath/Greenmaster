using Greenmaster.Contracts.Base;
using Greenmaster.Contracts.Dto.Users.Auth;

#pragma warning disable CS8618

namespace Greenmaster.Contracts.Commands.Authentication;

public class LoginUserCommand : CommandBase<LoginDto>
{
    public string Email { get; }

    public string Password { get; }

    public LoginUserCommand()
    {

    }

    public LoginUserCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
}