using System.Text.Json.Serialization;
using Greenmaster.Contracts.Base;
using Greenmaster.Contracts.Dto.Users;

namespace Greenmaster.Contracts.Commands.Authentication;

public class UpdateUserPasswordCommand : CommandBase<UserDto>
{
    public Guid UserId { get; set; }

    [JsonIgnore]
    public Guid ContextUserId { get; set; }

    public string OldPassword { get; set; }

    public string NewPassword { get; set; }
}