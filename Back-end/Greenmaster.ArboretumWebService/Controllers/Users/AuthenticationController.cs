using Greenmaster.Contracts.Commands.Authentication;
using Greenmaster.Contracts.Dto.Users;
using Greenmaster.Contracts.Dto.Users.Auth;
using Greenmaster.Core.WebService.Base;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract

namespace Greenmaster.ArboretumWebService.Controllers.Users;

[AllowAnonymous]
public class AuthenticationController : ApiControllerBase
{
    public AuthenticationController(IMediator mediator) : base(mediator){}
    [HttpPut("login")]
    [ProducesResponseType(typeof(Response<LoginDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> PostLogin([FromBody] LoginUserCommand command)
    {
        var response = await ExecutePostRequest(command);
        return response;
    }
    [HttpPost("confirmRegistration")]
    [ProducesResponseType(typeof(Response<UserDto>), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> PostConfirmRegistrationAsync([FromBody] ConfirmRegistrationCommand command)
    {
        if (null == command) return BadRequest();
        return await ExecutePostRequest(command);
    }

    [HttpPost("resetPassword")]
    [ProducesResponseType(typeof(Response<UserDto>), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> PostResetPassword([FromBody] ResetPasswordCommand command)
    {
        if (null == command) return BadRequest();
        return await ExecutePostRequest(command);
    }

    [HttpPut("updatePassword")]
    [Authorize]
    [ProducesResponseType(typeof(Response<UserDto>), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> PutUpdatePassword([FromBody] UpdateUserPasswordCommand command)
    {
        if (null == command) return BadRequest();
        command.ContextUserId = User.Id;
        return await ExecutePostRequest(command);
    }
}