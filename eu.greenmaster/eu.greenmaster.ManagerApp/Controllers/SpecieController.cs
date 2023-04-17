using eu.greenmaster.Models;
using eu.greenmaster.Models.Factories;
using eu.greenmaster.Models.Static;
using eu.greenmaster.Models.Static.Geographic;
using eu.greenmaster.Models.Static.Gradation;
using eu.greenmaster.Models.Static.Object.Organic;
using eu.greenmaster.Models.Static.PlantProperties;
using eu.greenmaster.Models.StaticData.Time.Durations;
using eu.greenmaster.Models.ViewModels;
using eu.greenmaster.Repository.Services.Specie;
using eu.greenmaster.Repository.Services.Type;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eu.greenmaster.ManagerApp.Controllers
{
    public class SpecieController : Controller
    {
        private readonly ISpecieService _modelService;
        private readonly IObjectTypeService<PlantType> _plantTypeService;

        public SpecieController(ISpecieService specieService, IObjectTypeService<PlantType> plantTypeService)
        {
            _modelService = specieService ?? throw new ArgumentNullException(nameof(specieService));
            _plantTypeService = plantTypeService;
        }

        // GET: Specie
        public Task<IActionResult> Index()
        {
            return Task.FromResult<IActionResult>(View());
        }
        
        public async Task<JsonResult> GetSpecies()
        {
            var species = (await _modelService.GetAll());
            var specieViewModels = new List<SpecieViewModel>();
            foreach (var specie in species) specieViewModels.Add(SpecieMapper.MapSpecieViewModel(specie));
            return Json(new { data = specieViewModels});
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

            return View(SpecieMapper.MapSpecieViewModel(specie));
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
                if (ModelState.IsValid)
                {
                    var requestedPlantType = (await _plantTypeService.GetById(specieViewModel.PlantTypeId)) ?? throw new ArgumentException($"Could not find a {nameof(PlantType)} with id={specieViewModel.PlantTypeId}");
                    specieViewModel.PlantType = requestedPlantType;
                    var specie = await SpecieMapper.MapSpecie(specieViewModel);
                    await _modelService.Add(specie);
                    return RedirectToAction(nameof(Index));
                }
                throw new ArgumentException(nameof(ModelState));
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
            ViewData["PlantType"] = new SelectList(await _plantTypeService.GetAll(), dataValueField: nameof(PlantType.Id), dataTextField: nameof(PlantType.Name), "---Select a plant-type---");
            ViewData["Month"] = new SelectList(Enum.GetNames(typeof(Month)));
            ViewData["Amount"] = new SelectList(Enum.GetNames(typeof(Amount)));
            ViewData["ClimateType"] = new SelectList(Enum.GetNames(typeof(ClimateType)));
            ViewData["Color"] = new SelectList(Enum.GetNames(typeof(Color)));
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
            return View(SpecieMapper.MapSpecieViewModel(specie));
        }

        // POST: Specie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SpecieViewModel specieViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var specie = await SpecieMapper.MapSpecie(specieViewModel);
                    await _modelService.Update(specie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _modelService.ExistsWithId(id))
                    {
                        return NotFound();
                    }
                }

                return RedirectToAction(nameof(Index));
            }


            await DefineViewData();
            return View(specieViewModel);
        }

        // GET: Specie/Delete/5
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