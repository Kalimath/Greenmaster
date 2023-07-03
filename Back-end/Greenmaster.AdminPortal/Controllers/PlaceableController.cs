﻿using Greenmaster.Core.Factories;
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
    private readonly IObjectTypeService<PlantType> _plantTypeService;
    private readonly ISpecieService _specieService;
    private readonly IModelFactory<Placeable, PlaceableViewModel> _placeableFactory;

    public PlaceableController(IPlantService plantService, IObjectTypeService<PlantType> plantTypeService, ISpecieService specieService,
        IModelFactory<Placeable, PlaceableViewModel> placeableFactory)
    {
        _plantService = plantService ?? throw new ArgumentNullException(nameof(plantService));
        _plantTypeService = plantTypeService ?? throw new ArgumentNullException(nameof(plantTypeService));
        _specieService = specieService ?? throw new ArgumentNullException(nameof(specieService));
        _placeableFactory = placeableFactory ?? throw new ArgumentNullException(nameof(placeableFactory));
    }

    public async Task<IActionResult> Index()
    {
        var plants = (await _plantService.GetAll());
        if(plants == null) plants = new List<Plant>();
        var viewModels = plants.Select(plant => _placeableFactory.ToViewModel(plant)).ToList();
        return View(viewModels);
    }
    
    public async Task<IActionResult> CreatePlant()
    {
        await DefineViewData();
        return View();
    }

    private async Task DefineViewData()
    {
        ViewData["PlantTypes"] = new SelectList(await _plantTypeService.GetAll());
        ViewData["Species"] = new SelectList(await _specieService.GetAll(), nameof(Specie.Id), nameof(Specie.ScientificName));
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