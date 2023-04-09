using Greenmaster_ASP.Models.Factories;
using Greenmaster_ASP.Models.Placeables;
using Greenmaster_ASP.Models.Services;
using Greenmaster_ASP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Greenmaster_ASP.Controllers;

public class PlaceableController : Controller
{
    private readonly IContextService<Plant, Guid> _plantService;

    public PlaceableController(IContextService<Plant, Guid> plantService)
    {
        _plantService = plantService;
    }

    public async Task<IActionResult> Index()
    {
        var plants = (await _plantService.GetAll());
        var viewModels = new List<PlaceableViewModel>();
        foreach (var plant in plants) viewModels.Add(PlaceableFactory.ToViewModel(plant));
        return View(viewModels);
    }
    
    public IActionResult CreatePlant()
    {
        throw new NotImplementedException();
    }
    
    public IActionResult CreateStructure()
    {
        throw new NotImplementedException();
    }

    public IActionResult Details()
    {
        throw new NotImplementedException();
    }

    public IActionResult Delete()
    {
        throw new NotImplementedException();
    }

    public IActionResult Edit()
    {
        throw new NotImplementedException();
    }
}