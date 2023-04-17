using Microsoft.AspNetCore.Mvc;

namespace eu.greenmaster.WebService.Base;

[ApiController]
[Route("api/v{v:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[Produces("application/json")]
public class ApiControllerBase : ControllerBase
{
    public ApiControllerBase()
    {
    }
}
     