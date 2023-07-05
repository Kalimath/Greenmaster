using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Greenmaster.Contracts.Base;
using Greenmaster.Contracts.Dto.Users;

namespace Greenmaster.Core.Database.Commands.Users;

public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
{
    public AddUserCommandValidator()
    {
        RuleFor(u => u.Email).NotEmpty().EmailAddress();
        RuleFor(u => u.CompanyId).NotEmpty();
        RuleFor(u => u.Phone).Matches("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$").When(u => u != null);
    }
}
public class AddUserCommand : CommandBase<UserDto>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    [Required]
    public string Email { get; set; }

    public string? Phone { get; set; }

    public Guid CompanyId { get; set; }

    public Guid RoleId { get; set; }
}