using Greenmaster.Core.Mappers;
using Greenmaster.Core.Models;
using Greenmaster.Core.Models.Placeables;
using Greenmaster.Core.Models.ViewModels;
using Greenmaster.Core.Services.Placeables;
using Greenmaster.Core.Services.Specie;
using Greenmaster.Core.Services.Type;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
// ReSharper disable TooManyDependencies

namespace Greenmaster.AdminPortal.Controllers;

public class PlaceableController : Controller
{
    private readonly IPlantService _plantService;
    private readonly ISpecieService _specieService;
    private readonly IViewModelMapper<Placeable, PlaceableViewModel> _placeableMapper;

    public PlaceableController(IPlantService plantService, ISpecieService specieService,
        IViewModelMapper<Placeable, PlaceableViewModel> placeableMapper)
    {
        _plantService = plantService ?? throw new ArgumentNullException(nameof(plantService));
        _specieService = specieService ?? throw new ArgumentNullException(nameof(specieService));
        _placeableMapper = placeableMapper ?? throw new ArgumentNullException(nameof(placeableMapper));
    }

    public async Task<IActionResult> Index()
    {
        var plants = await _plantService.GetAll();
        var viewModels = plants.Select(plant => _placeableMapper.ToViewModel(plant)).ToList();
        return View(viewModels);
    }
    
    public async Task<IActionResult> CreatePlant()
    {
        await DefineViewData();
        return View();
    }

    public IActionResult CreateStructure()
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> AddPlant(int id)
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

    private async Task DefineViewData()
    {
        ViewData["Species"] = new SelectList(await _specieService.GetAll(), nameof(Specie.Id), nameof(Specie.ScientificName));
    }
}