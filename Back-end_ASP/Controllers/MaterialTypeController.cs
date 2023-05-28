using Greenmaster_ASP.Models.Design;
using Greenmaster_ASP.Models.Services.MaterialType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// ReSharper disable MethodNameNotMeaningful

namespace Greenmaster_ASP.Controllers;

public class MaterialTypeController : Controller
{
    private readonly IMaterialTypeService _modelService;

    public MaterialTypeController(IMaterialTypeService modelService)
    {
        _modelService = modelService;
    }
    
    public async Task<IActionResult> Index()
    {
        return View(await _modelService.GetAll());
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MaterialType model)
    {
        try
        {
            if (!ModelState.IsValid) throw new ArgumentException($"Invalid {nameof(ModelState)}");
            await _modelService.Add(model);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View(model);
        }
    }
    
    
    public async Task<IActionResult> Edit(int id)
    {
        MaterialType materialType;
        try
        {
            materialType = await _modelService.GetById(id);
        }
        catch (Exception)
        {
            return NotFound();
        }

        return View(materialType);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, MaterialType model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _modelService.Update(model);
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

        return View(model);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        if (!await _modelService.ExistsWithId(id))
            return NotFound();

        await _modelService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}