using eu.greenmaster.EFCore.Services;
using eu.greenmaster.WebService.Base;
using Microsoft.AspNetCore.Mvc;

namespace eu.greenmaster.WebService.Controllers;

public class SpecieController : ApiControllerBase
{
    private readonly ISpecieService _specieService;

    public SpecieController( ISpecieService specieService)
    {
        _specieService = specieService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAccessories()
    {
        return Ok(await _specieService.GetAll());
    }
}