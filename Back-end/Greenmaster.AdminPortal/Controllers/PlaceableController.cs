﻿using Greenmaster.Core.Factories;
using Greenmaster.Core.Models.ViewModels;
using Greenmaster.Core.Services.Placeables;
using Microsoft.AspNetCore.Mvc;

namespace Greenmaster.AdminPortal.Controllers;

public class PlaceableController : Controller
{
    private readonly IPlantService _plantService;

    public PlaceableController(IPlantService plantService)
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