using System.Drawing;
using Greenmaster.Core.Factories;
using Greenmaster.Core.Models.Design;
using Greenmaster.Core.Models.Extensions;
using Greenmaster.Core.Models.ViewModels;
using Greenmaster.Core.Services.GardenStyle;
using Greenmaster.Core.Services.MaterialType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StaticData.Coloring;
using StaticData.Design;
using StaticData.Gradation;
using StaticData.PlantProperties;
using StaticData.Taxonomy;
using Size = StaticData.Measuring.Size;

namespace Greenmaster.AdminPortal.Controllers;

public class GardenStyleController : Controller
{
    private IModelFactory<GardenStyle, GardenStyleViewModel> GardenStyleFactory { get; }
    private readonly IGardenStyleService _modelService;
    private readonly IMaterialTypeService _materialTypeService;

    public GardenStyleController(IGardenStyleService service, IMaterialTypeService materialTypeService, IModelFactory<GardenStyle, GardenStyleViewModel> gardenStyleFactory)
    {
        GardenStyleFactory = gardenStyleFactory ?? throw new ArgumentNullException(nameof(gardenStyleFactory));
        _modelService = service ?? throw new ArgumentNullException(nameof(service));
        _materialTypeService = materialTypeService ?? throw new ArgumentNullException(nameof(materialTypeService));
    }

    public async Task<IActionResult> Index()
    {
        return View(await _modelService.GetAll());
    }

    public async Task<IActionResult> Create()
    {
        await DefineViewData();
        return View();
    }

    //Post: api/GardenStyle/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(GardenStyleViewModel viewModel)
    {
        try
        {
            if (!ModelState.IsValid) throw new ArgumentException($"Invalid {nameof(ModelState)}");
            
            
            var materials = new List<MaterialType>();
            foreach (var id in viewModel.MaterialTypeIds)
            {
                materials.Add(await _materialTypeService.GetById(id));
            }
            viewModel.Materials = materials.ToArray();
            
            var gardenStyle = await GardenStyleFactory.Create(viewModel);
            await _modelService.Add(gardenStyle);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            await DefineViewData();
            return View(viewModel);
        }
        
    }

    public async Task<IActionResult> Details(int id)
    {
        GardenStyleViewModel viewModel;
        try
        {
            var gardenStyle = (await _modelService.GetById(id)) ?? throw new ArgumentException("No gardenStyle found with id= " + id);
            viewModel = GardenStyleFactory.ToViewModel(gardenStyle);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return NotFound();
        }
        
        return View(viewModel);
    }

    public async Task<IActionResult> Edit(int id)
    {
        GardenStyle gardenStyle;
        try
        {
            gardenStyle = await _modelService.GetById(id);
        }
        catch (Exception)
        {
            return NotFound();
        }

        await DefineViewData();
        return View(GardenStyleFactory.ToViewModel(gardenStyle));
    }
    
    // Put: api/GardenStyle/PutGardenStyle
    // To protect from overposting attacks, please enable the specific properties you want to bind to.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, GardenStyleViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var gardenStyle = await GardenStyleFactory.Create(viewModel);
                await _modelService.Update(gardenStyle);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!await _modelService.ExistsWithId(id))
                    return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        await DefineViewData();
        return View(viewModel);
    }

    
    public async Task<IActionResult> Delete(int id)
    {
        if (!await _modelService.ExistsWithId(id))
            return NotFound();

        try
        {
            return View(await _modelService.GetById(id));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return NotFound();
        }
    }
    
    
    [HttpPost, ActionName("DeleteConfirmed")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (!await _modelService.ExistsWithId(id))
            return NotFound();

        await _modelService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
    

    private async Task DefineViewData()
    {
        ViewData["Colors"] = new SelectList(ColorPallet.BaseColors().GetNames(),$"---Select {nameof(Color)}s---");
        ViewData["Amounts"] = new SelectList(Enum.GetNames(typeof(Amount)),$"---Select {nameof(Amount)}---");
        ViewData["Concepts"] = new SelectList(Enum.GetNames(typeof(GardenStyleConcept)), $"---Select concepts---");
        ViewData["Shapes"] = new SelectList(Enum.GetNames(typeof(Shape)),$"---Select {nameof(Shape)}s---");
        ViewData["Sizes"] = new SelectList(Enum.GetNames(typeof(Size)), $"---Select {nameof(Size)}---");
        ViewData["PlantGenera"] = new SelectList(Enum.GetNames(typeof(PlantGenus)), $"---Select Genera---");
        ViewData["MaterialTypes"] = new SelectList(await _materialTypeService.GetAll(), nameof(MaterialType.Id), nameof(MaterialType.Name),$"---Select {nameof(MaterialType)}s---");
    }
}