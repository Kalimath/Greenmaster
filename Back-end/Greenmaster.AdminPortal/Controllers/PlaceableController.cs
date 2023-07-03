using Greenmaster.Core.Factories;
using Greenmaster.Core.Models.Placeables;
using Greenmaster.Core.Models.ViewModels;
using Greenmaster.Core.Services.Placeables;
using Microsoft.AspNetCore.Mvc;

namespace Greenmaster.AdminPortal.Controllers;

public class PlaceableController : Controller
{
    private readonly IPlantService _plantService;
    private readonly IModelFactory<Placeable, PlaceableViewModel> _placeableFactory;

    public PlaceableController(IPlantService plantService, IModelFactory<Placeable, PlaceableViewModel> placeableFactory)
    {
        _plantService = plantService ?? throw new ArgumentNullException(nameof(plantService));
        _placeableFactory = placeableFactory ?? throw new ArgumentNullException(nameof(placeableFactory));
    }

    public async Task<IActionResult> Index()
    {
        var plants = (await _plantService.GetAll());
        if(plants == null) plants = new List<Plant>();
        var viewModels = plants.Select(plant => _placeableFactory.ToViewModel(plant)).ToList();
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