using System.Security.Claims;
using FluentValidation;
using Greenmaster.Contracts.Dto.Users;
using Greenmaster.Core.Database.Commands.Users;
using Greenmaster.Core.Dxos.Users;
using Greenmaster.Core.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Greenmaster.Core.Database.Handlers.Commands.Users;

public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, RoleDto>
{
    private readonly RoleManager<Role> _roleManager;
    private readonly IRolesDxos _roleDxos;

    public AddRoleCommandHandler(RoleManager<Role> roleManager, IRolesDxos rolesDxo)
    {
        this._roleManager = roleManager;
        _roleDxos = rolesDxo;
    }

    public async Task<RoleDto> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var result = await new AddRoleCommandValidator().ValidateAsync(request, cancellationToken);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        var role = new Role(request.RoleName);

        await _roleManager.CreateAsync(role);

        //var allClaims = await _roleManager.GetClaimsAsync(r);
        //var allPermissions = Permissions.GeneratePermissionsForModule(module);
        foreach (var permission in request.Permissions)
        {
            await _roleManager.AddClaimAsync(role, new Claim("Permission", permission));
        }
        var roleDto = _roleDxos.MapRoleDto(role);
        var claims = await _roleManager.GetClaimsAsync(role);
        foreach (var permission in claims)
        {
            roleDto.Permissions.Add(permission.Value);
        }
        return roleDto;
    }
}