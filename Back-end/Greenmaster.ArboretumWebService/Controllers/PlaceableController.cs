using Greenmaster.Core.Mappers;
using Greenmaster.Core.Models.Placeables;
using Greenmaster.Core.Models.ViewModels;
using Greenmaster.Core.Services.Placeables;
using Microsoft.AspNetCore.Mvc;

namespace Greenmaster.ArboretumWebService.Controllers;

[ApiController]
[Route("[controller]")]
public class PlaceableController : ControllerBase
{
    private readonly IPlantService _plantService;
    private readonly IStructureService _structureService;
    private readonly IViewModelMapper<Placeable, PlaceableViewModel> _placeableMapper;

    public PlaceableController(IPlantService plantService, IStructureService structureService, IViewModelMapper<Placeable, PlaceableViewModel> placeableMapper)
    {
        _plantService = plantService;
        _structureService = structureService;
        _placeableMapper = placeableMapper;
    }

    [HttpGet(Name = "GetPlants")]
    public async Task<IEnumerable<PlaceableViewModel>> GetPlants()
    {
        var plants = (await _plantService.GetAll());
        var viewModels = plants.Select(plant => _placeableMapper.ToViewModel(plant)).ToList();
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