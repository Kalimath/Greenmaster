using Greenmaster.Contracts.Commands.Users;
using Greenmaster.Contracts.Queries.Users;
using Greenmaster.Core.WebService.Base;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract

namespace Greenmaster.ArboretumWebService.Controllers.Users;

[AllowAnonymous]
public class RolesController : ApiControllerBase
{
    public RolesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Authorize(Policy = "Permissions.Roles.Read")]
    public async Task<IActionResult> GetRoles()
    {
        return await ExecuteRequest(new GetAllRolesQuery());
    }

    [HttpGet("permissions")]
    [Authorize(Policy = "Permissions.Roles.Read")]
    public async Task<IActionResult> GetAllPermissions()
    {

        return await ExecuteRequest(new GetAllPermissionsQuery());
    }

    [HttpPost]
    public async Task<IActionResult> PostRole(AddRoleCommand command)
    {
        if (command == null) return BadRequest();
        return await ExecuteRequest(command);
    }


    [HttpDelete]
    [Authorize(Policy = "Permissions.Roles.Delete")]
    public async Task<IActionResult> DeleteRole(DeleteRoleCommand command)
    {
        if (command == null) return BadRequest();
        return await ExecuteRequest(command);
    }

}