using Greenmaster.Core.Factories;
using Greenmaster.Core.Models.Placeables;
using Greenmaster.Core.Models.ViewModels;
using Greenmaster.Core.Services.Placeables;
using Microsoft.AspNetCore.Mvc;

namespace Greenmaster.ArboretumWebService.Controllers.Arboretum;

[ApiController]
[Route("[controller]")]
public class PlaceableController : ControllerBase
{
    private readonly IPlantService _plantService;
    private readonly IStructureService _structureService;
    private readonly IModelFactory<Placeable, PlaceableViewModel> _placeableFactory;

    public PlaceableController(IPlantService plantService, IStructureService structureService, IModelFactory<Placeable, PlaceableViewModel> placeableFactory)
    {
        _plantService = plantService;
        _structureService = structureService;
        _placeableFactory = placeableFactory;
    }

    [HttpGet(Name = "GetPlants")]
    public async Task<IEnumerable<PlaceableViewModel>> GetPlants()
    {
        var plants = (await _plantService.GetAll());
        var viewModels = plants.Select(plant => _placeableFactory.ToViewModel(plant)).ToList();
        return viewModels;
    }

    /*
    [HttpGet(Name = "GetStructures")]
    [Route("/GetStructures")]
    public async Task<IEnumerable<PlaceableViewModel>> GetStructures()
    {
        var structures = (await _structureService.GetAll());
        var viewModels = structures.Select(plant => _placeableFactory.ToViewModel(plant)).ToList();
        return viewModels;
    }*/
}