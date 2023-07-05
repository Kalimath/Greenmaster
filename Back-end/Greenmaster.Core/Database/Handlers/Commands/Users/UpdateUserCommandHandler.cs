using FluentValidation;
using Greenmaster.Contracts.Base;
using Greenmaster.Contracts.Dto.Users;
using Greenmaster.Core.Database.Commands.Users;
using Greenmaster.Core.Dxos.Users;
using Greenmaster.Core.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Greenmaster.Core.Database.Handlers.Commands.Users;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
{
    private readonly UserManager<User> _repository;
    private readonly IUsersDxos _usersDxos;

    public UpdateUserCommandHandler(UserManager<User> repository, IUsersDxos usersDxo)
    {
        this._repository = repository;
        this._usersDxos = usersDxo;
    }
    public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var result = await new UpdateUserCommandValidator().ValidateAsync(request);
        if (!result.IsValid)
            throw new ValidationException(result.Errors);

        var u = await _repository.FindByIdAsync(request.Id.ToString());

        if (!string.IsNullOrEmpty(request.Email)) u.Email = request.Email;
        if (!string.IsNullOrEmpty(request.FirstName)) u.FirstName = request.FirstName;
        if (!string.IsNullOrEmpty(request.LastName)) u.LastName = request.LastName;
        if (!string.IsNullOrEmpty(request.Phone)) u.Phone = request.Phone;

        await _repository.UpdateAsync(u);

        return _usersDxos.MapUserDto(u);
    }
    
}