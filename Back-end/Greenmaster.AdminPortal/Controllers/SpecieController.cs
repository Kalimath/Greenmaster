using Greenmaster.Core.Extensions;
using Greenmaster.Core.Mappers;
using Greenmaster.Core.Models;
using Greenmaster.Core.Models.ViewModels;
using Greenmaster.Core.Services.Specie;
using Greenmaster.Core.Services.Type;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StaticData.Coloring;
using StaticData.Geographic;
using StaticData.Gradation;
using StaticData.Object.Organic;
using StaticData.PlantProperties;
using StaticData.Taxonomy;
using StaticData.Time.Durations;

namespace Greenmaster.AdminPortal.Controllers
{
    public class SpecieController : Controller
    {
        private readonly ISpecieService _modelService;
        private readonly IObjectTypeService<PlantType> _plantTypeService;
        private readonly IViewModelMapper<Specie, SpecieViewModel> _specieMapper;

        public SpecieController(ISpecieService specieService, IObjectTypeService<PlantType> plantTypeService, IViewModelMapper<Specie, SpecieViewModel> specieMapper)
        {
            _modelService = specieService ?? throw new ArgumentNullException(nameof(specieService));
            _plantTypeService = plantTypeService;
            _specieMapper = specieMapper;
        }

        // GET: Specie
        public Task<IActionResult> Index()
        {
            return Task.FromResult<IActionResult>(View());
        }
        
        // GET: Specie/ByGenus/ginkgo
        [HttpGet]
        public async Task<IActionResult> ByGenus(string genus)
        {
            if (string.IsNullOrEmpty(genus))
            {
                return RedirectToAction("Index");
            }

            var species = await _modelService.GetAllByGenus(Enum.Parse<PlantGenus>(genus));

            if (species == null || species.Count == 0)
            {
                return RedirectToAction("Index");
            }
            var specieViewModels = ToViewModels(species);

            return View(specieViewModels);
        }

        public async Task<JsonResult> GetSpecies()
        {
            var species = (await _modelService.GetAll());
            var specieViewModels = ToViewModels(species);
            return Json(new { data = specieViewModels});
        }

        private List<SpecieViewModel> ToViewModels(List<Specie> species)
        {
            var specieViewModels = new List<SpecieViewModel>();
            foreach (var specie in species) specieViewModels.Add(_specieMapper.ToViewModel(specie));
            return specieViewModels;
        }

        // GET: Specie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Specie specie;
            try
            {
                specie = await _modelService.GetById((int)id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }

            return View(_specieMapper.ToViewModel(specie));
        }

        // GET: Specie/Create
        public async Task<IActionResult> Create()
        {
            await DefineViewData();
            return View();
        }

        // POST: Specie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecieViewModel specieViewModel)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(nameof(ModelState));
                var requestedPlantType = (await _plantTypeService.GetById(specieViewModel.PlantTypeId)) ?? throw new ArgumentException($"Could not find a {nameof(PlantType)} with id={specieViewModel.PlantTypeId}");
                specieViewModel.PlantType = requestedPlantType;
                var specie = await _specieMapper.ToModel(specieViewModel);
                await _modelService.Add(specie);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                await DefineViewData();
                return View(specieViewModel);
            }
        }

        private async Task DefineViewData()
        {
            ViewData["LifeCycle"] = new SelectList(Enum.GetNames(typeof(Lifecycle)));
            ViewData["PlantGenera"] = new SelectList(Enum.GetNames(typeof(PlantGenus)));
            ViewData["PlantType"] = new SelectList(await _plantTypeService.GetAll(), dataValueField: nameof(PlantType.Id), dataTextField: nameof(PlantType.Name));
            ViewData["Month"] = new SelectList(Enum.GetNames(typeof(Month)));
            ViewData["Amount"] = new SelectList(Enum.GetNames(typeof(Amount)));
            ViewData["ClimateType"] = new SelectList(Enum.GetNames(typeof(ClimateType)));
            ViewData["Color"] = new SelectList(ColorPallet.Colors().GetNames());
            ViewData["Shape"] = new SelectList(Enum.GetNames(typeof(Shape)));
        }

        // GET: Specie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            Specie specie;
            try
            {
                specie = await _modelService.GetById((int)id!);
            }
            catch (Exception)
            {
                return NotFound();
            }

            await DefineViewData();
            return View(_specieMapper.ToViewModel(specie));
        }
        
        // POST: Specie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SpecieViewModel specieViewModel)
        {
            //TODO BUG: fix edit method
            if (ModelState.IsValid || ModelState["Image"]!.ValidationState == ModelValidationState.Invalid)
            {
                try
                {
                    var specie = await _specieMapper.ToModel(specieViewModel);
                    await _modelService.Update(specie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _modelService.ExistsWithId(id))
                    {
                        return NotFound();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }


            await DefineViewData();
            return View(specieViewModel);
        }
        
        // GET: Specie/DeleteConfirmed/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || !await _modelService.ExistsWithId((int)id))
            {
                return NotFound();
            }

            try
            {
                return View(await _modelService.GetById((int)id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }

        // POST: Specie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!await _modelService.ExistsWithId(id))
            {
                return NotFound();
            }

            await _modelService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}