using Greenmaster.Contracts.Base;
using Greenmaster.Contracts.Dto.Users;

namespace Greenmaster.Contracts.Commands.Authentication;

public class ConfirmRegistrationCommand : CommandBase<UserDto>
{
    public string Email { get; }
    public string VerificationToken { get; }
    public string Password { get; }
    public ConfirmRegistrationCommand(string email, string verificationToken, string password)
    {
        Email = email;
        VerificationToken = verificationToken;
        Password = password;
    }
}