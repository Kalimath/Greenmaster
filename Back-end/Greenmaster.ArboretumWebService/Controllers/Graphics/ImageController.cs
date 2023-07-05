using Greenmaster.Core.Database.Commands.Graphic;
using Greenmaster.Core.WebService.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Greenmaster.ArboretumWebService.Controllers.Graphics;

[Controller]
public class ImageController : ApiControllerBase
{

    public ImageController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> UploadImage([FromForm] AddImageCommand command)
    {
        if (command == null) return BadRequest();
        return await ExecuteRequest(command);
    }
}