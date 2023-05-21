using Greenmaster_ASP.Models.Design;
using Greenmaster_ASP.Models.Factories;
using Greenmaster_ASP.Models.Services.GardenStyle;
using Greenmaster_ASP.Models.Static;
using Greenmaster_ASP.Models.Static.Design;
using Greenmaster_ASP.Models.Static.Gradation;
using Greenmaster_ASP.Models.Static.PlantProperties;
using Greenmaster_ASP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Greenmaster_ASP.Controllers;

public class GardenStyleController : Controller
{
    private readonly IGardenStyleService _service;

    public GardenStyleController(IGardenStyleService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public async Task<IActionResult> Index()
    {
        return View(await _service.GetAll());
    }

    public IActionResult CreateGardenStyle()
    {
        DefineViewData();
        return View();
    }

    //Post: api/GardenStyle/CreateGardenStyle
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateGardenStyle(GardenStyleViewModel viewModel)
    {
        try
        {
            if (!ModelState.IsValid) throw new ArgumentException($"Invalid {nameof(ModelState)}");
            var gardenStyle = GardenStyleFactory.Create(viewModel);
            await _service.Add(gardenStyle);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            DefineViewData();
            return View(viewModel);
        }
        
    }

    public async Task<IActionResult> Details(int id)
    {
        GardenStyleViewModel viewModel;
        try
        {
            var gardenStyle = (await _service.GetById(id)) ?? throw new ArgumentException("No gardenStyle found with id= " + id);
            viewModel = GardenStyleFactory.ToViewModel(gardenStyle);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return NotFound();
        }

        
        return View(viewModel);
    }

    public IActionResult Edit()
    {
        throw new NotImplementedException();
    }

    public IActionResult Delete()
    {
        return View();
    }
    

    private void DefineViewData()
    {
        ViewData["Colors"] = new SelectList(Enum.GetNames(typeof(Color)));
        ViewData["Amounts"] = new SelectList(Enum.GetNames(typeof(Amount)));
        ViewData["Concepts"] = new SelectList(Enum.GetNames(typeof(GardenStyleConcept)));
        ViewData["Shapes"] = new SelectList(Enum.GetNames(typeof(Shape)));
    }
}