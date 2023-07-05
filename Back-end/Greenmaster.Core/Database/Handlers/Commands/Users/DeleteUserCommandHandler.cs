using FluentValidation;
using Greenmaster.Contracts.Dto.Users;
using Greenmaster.Core.Database.Commands.Users;
using Greenmaster.Core.Dxos.Users;
using Greenmaster.Core.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Greenmaster.Core.Database.Handlers.Commands.Users;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, UserDto>
{
    private readonly UserManager<User> _repository;
    private readonly IUsersDxos _usersDxos;

    public DeleteUserCommandHandler(UserManager<User> repository, IUsersDxos usersDxo)
    {
        _repository = repository;
        _usersDxos = usersDxo;
    }
    public async Task<UserDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var result = await new DeleteUserCommandValidator().ValidateAsync(request);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        var u = await _repository.FindByIdAsync(request.Id.ToString());
        await _repository.DeleteAsync(u);

        return _usersDxos.MapUserDto(u);
    }
}