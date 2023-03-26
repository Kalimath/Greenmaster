using Greenmaster_ASP.Models;
using Greenmaster_ASP.Models.Services;
using Greenmaster_ASP.Models.Static.Gradation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Greenmaster_ASP.Controllers;

public class ObjectTypeController : Controller
{
    private readonly IObjectTypeService<PlantType> _plantTypeService;
    private readonly IObjectTypeService<ObjectType> _objectTypeService;
    private readonly IObjectTypeService<StructureType> _structureTypeService;

    public ObjectTypeController(IObjectTypeService<ObjectType> objectTypeService, IObjectTypeService<StructureType> structureTypeService, IObjectTypeService<PlantType> plantTypeService)
    {
        _objectTypeService = objectTypeService;
        _structureTypeService = structureTypeService;
        _plantTypeService = plantTypeService;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var objectTypes = new List<ObjectType>();
        objectTypes.AddRange(await _plantTypeService.GetAll());
        objectTypes.AddRange(await _structureTypeService.GetAll());
        return View(objectTypes);
    }
    
    public IActionResult CreatePlantType()
    {
        DefineViewData();
        return View();
    }
    
    // POST: ObjectType/CreatePlantType
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreatePlantType(PlantType plantType)
    {
        try
        {
            if (!ModelState.IsValid) throw new ArgumentException($"Invalid {nameof(ModelState)}");
            await _plantTypeService.Add(plantType);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            DefineViewData();
            return View(plantType);
        }
    }
    
    public IActionResult CreateStructureType()
    {
        
        return View();
    }
    
    // POST: ObjectType/CreatePlantType
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreateStructureType(StructureType structureType)
    {
        try
        {
            if (!ModelState.IsValid) throw new ArgumentException($"Invalid {nameof(ModelState)}");
            await _structureTypeService.Add(structureType);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            DefineViewData();
            return View(structureType);
        }
    }
    
    public async Task<IActionResult> Details(int id)
    {
        ObjectType objectType;
        try
        {
            objectType = (await _objectTypeService.GetById(id)) ?? throw new ArgumentException("No ObjectType found with id= " + id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return NotFound();
        }
        
        return View(objectType);
    }

    public IActionResult Edit()
    {
        throw new NotImplementedException();
    }
    

    public IActionResult Delete()
    {
        throw new NotImplementedException();
    }
    
    
    private void DefineViewData()
    {
        ViewData["Canopy"] = new SelectList(Enum.GetNames(typeof(Permeability)));
    }

}