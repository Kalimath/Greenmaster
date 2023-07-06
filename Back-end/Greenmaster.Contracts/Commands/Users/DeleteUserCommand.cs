using FluentValidation;
using Greenmaster.Contracts.Base;
using Greenmaster.Contracts.Dto.Users;

namespace Greenmaster.Contracts.Commands.Users;

public class DeleteUserCommand : CommandBase<UserDto>
{
    public Guid Id { get; set; }
}

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}