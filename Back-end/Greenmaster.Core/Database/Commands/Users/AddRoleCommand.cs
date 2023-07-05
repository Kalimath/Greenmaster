using FluentValidation;
using Greenmaster.Contracts.Base;
using Greenmaster.Contracts.Dto.Users;

namespace Greenmaster.Core.Database.Commands.Users;

public class AddRoleCommand : CommandBase<RoleDto>
{
    public string RoleName { get; set; }
    public IEnumerable<string> Permissions { get; set; }
}

public class AddRoleCommandValidator : AbstractValidator<AddRoleCommand>
{
    public AddRoleCommandValidator()
    {
        RuleFor(c => c.RoleName).NotEmpty();
    }
}