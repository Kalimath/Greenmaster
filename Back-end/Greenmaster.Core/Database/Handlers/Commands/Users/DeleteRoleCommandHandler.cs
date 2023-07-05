using FluentValidation;
using Greenmaster.Contracts.Dto.Users;
using Greenmaster.Core.Database.Commands.Users;
using Greenmaster.Core.Dxos.Users;
using Greenmaster.Core.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Greenmaster.Core.Database.Handlers.Commands.Users;

public class DeleteRoleCommandHandler: IRequestHandler<DeleteRoleCommand, RoleDto>
{
    private readonly RoleManager<Role> _repository;
    private readonly IRolesDxos _rolesDxos;

    public DeleteRoleCommandHandler(RoleManager<Role> repository, IRolesDxos rolesDxo)
    {
        this._repository = repository;
        _rolesDxos = rolesDxo;
    }
    public async Task<RoleDto> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var result = await new DeleteRoleCommandValidator().ValidateAsync(request, cancellationToken);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        var role = await _repository.FindByIdAsync(request.Id.ToString());
        if(role == null)
        {
            throw new NullReferenceException();
        }
        role.IsDeleted = true;
        await _repository.UpdateAsync(role);

        return _rolesDxos.MapRoleDto(role);
    }  
}