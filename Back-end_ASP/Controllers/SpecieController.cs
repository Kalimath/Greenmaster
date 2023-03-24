using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Greenmaster_ASP.Models;
using Greenmaster_ASP.Models.Factories;
using Greenmaster_ASP.Models.Services;
using Greenmaster_ASP.Models.Static;
using Greenmaster_ASP.Models.Static.Geographic;
using Greenmaster_ASP.Models.Static.Gradation;
using Greenmaster_ASP.Models.Static.Object.Organic;
using Greenmaster_ASP.Models.Static.PlantProperties;
using Greenmaster_ASP.Models.StaticData.Time.Durations;
using Greenmaster_ASP.Models.ViewModels;

namespace Greenmaster_ASP.Controllers
{
    public class SpecieController : Controller
    {
        private readonly ISpecieService _modelService;

        public SpecieController(ISpecieService specieService)
        {
            _modelService = specieService ?? throw new ArgumentNullException(nameof(specieService));
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
            foreach (var specie in species) specieViewModels.Add(SpecieFactory.ToViewModel(specie));
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

            return View(SpecieFactory.ToViewModel(specie));
        }

        // GET: Specie/Create
        public IActionResult Create()
        {
            DefineViewData();
            return View();
        }

        // POST: Specie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecieViewModel specieViewModel)
        {
            if (ModelState.IsValid)
            {
                var specie = await SpecieFactory.Create(specieViewModel);
                await _modelService.Add(specie);
                return RedirectToAction(nameof(Index));
            }

            DefineViewData();
            return View(specieViewModel);
        }

        private void DefineViewData()
        {
            ViewData["LifeCycle"] = new SelectList(Enum.GetNames(typeof(Lifecycle)));
            ViewData["PlantType"] = new SelectList(PlantType.GetAllNames());
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

            DefineViewData();
            return View(SpecieFactory.ToViewModel(specie));
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
                    var specie = await SpecieFactory.Create(specieViewModel);
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


            DefineViewData();
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