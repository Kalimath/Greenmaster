using Microsoft.AspNetCore.Mvc;

namespace Greenmaster_ASP.Controllers;

public class PlaceableController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult CreatePlant()
    {
        throw new NotImplementedException();
    }
    
    public IActionResult CreateStructure()
    {
        throw new NotImplementedException();
    }
}