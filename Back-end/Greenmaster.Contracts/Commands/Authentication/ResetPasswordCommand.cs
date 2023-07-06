using Greenmaster.Contracts.Base;
using Greenmaster.Contracts.Dto.Users;

namespace Greenmaster.Contracts.Commands.Authentication;

public class ResetPasswordCommand : CommandBase<UserDto>
{
    public string Email { get; set; }
}