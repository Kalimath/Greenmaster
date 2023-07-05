using FluentValidation;
using Greenmaster.Contracts.Base;
using Greenmaster.Contracts.Dto.Users;

namespace Greenmaster.Core.Database.Commands.Users;

public class DeleteRoleCommand : CommandBase<RoleDto>
{
    public Guid Id { get; set; }
}

public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
{
    public DeleteRoleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}