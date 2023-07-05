using Greenmaster.Core.Database.Commands.Users;
using Greenmaster.Core.Database.Queries.Users;
using Greenmaster.Core.WebService.Base;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Greenmaster.ArboretumWebService.Controllers.Users;

[AllowAnonymous]
public class UsersController : ApiControllerBase
{
    public UsersController(IMediator mediator) : base(mediator)
    {

    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        return await ExecuteRequest(new GetAllUsersQuery());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(string id)
    {
        return await ExecuteRequest(new GetUserByIdQuery(Guid.Parse(id)));
    }

    [HttpPost]
    public async Task<IActionResult> PostUser(AddUserCommand command)
    {
        if (command == null) return BadRequest();
        return await ExecuteRequest(command);
    }

    [HttpPut]
    public async Task<IActionResult> PutUser(UpdateUserCommand command)
    {
        if (command == null) return BadRequest();
        return await ExecuteRequest(command);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser(DeleteUserCommand command)
    {
        if (command == null) return BadRequest();
        return await ExecuteRequest(command);
    }
}