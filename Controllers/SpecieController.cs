using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Greenmaster_ASP.Models;
using Greenmaster_ASP.Models.Arboretum;
using Greenmaster_ASP.Models.Factories;
using Greenmaster_ASP.Models.Services;
using Greenmaster_ASP.Models.Static.Geographic;
using Greenmaster_ASP.Models.Static.Gradation;
using Greenmaster_ASP.Models.Static.Object.Organic;
using Greenmaster_ASP.Models.StaticData;
using Greenmaster_ASP.Models.StaticData.Time.Durations;
using Greenmaster_ASP.Models.ViewModels;

namespace Greenmaster_ASP.Controllers
{
    public class SpecieController : Controller
    {
        private readonly ArboretumContext _context;
        private readonly ISpecieService _specieService;

        public SpecieController(ArboretumContext context, ISpecieService specieService)
        {
            _context = context;
            _specieService = specieService;
        }

        // GET: Specie
        public async Task<IActionResult> Index()
        {
            return View(await _specieService.GetSpecies());
        }

        // GET: Specie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Species == null)
            {
                return NotFound();
            }

            var specie = await _specieService.GetSpecieById((int)id);
            if (specie == null)
            {
                return NotFound();
            }

            return View(specie);
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
        public async Task<IActionResult> Create(
            [Bind(
                "Genus,Species,Cultivar,Type,CommonNames,Description")]
            Specie specie)
        {
            
            if (ModelState.IsValid)
            {
                _context.Species.Add(specie);
                await _context.SaveChangesAsync();
                
                return await Details(specie.Id);
                /*createdSpecie = SpecieFactory.Create(specieViewModel);
                await _specieService.AddSpecie(createdSpecie);
                return await Details(createdSpecie.SpecieId);*/
            }

            DefineViewData();
            return View(specie);
        }

        private void DefineViewData()
        {
            ViewData["LifeCycle"] = new SelectList(Enum.GetNames(typeof(Lifecycle)));
            ViewData["Type"] = new SelectList(PlantType.GetAllNames());
            /*ViewData["Amount"] = new SelectList(Enum.GetNames(typeof(Amount)));
            ViewData["ClimateType"] = new SelectList(Enum.GetNames(typeof(ClimateType)));
            ViewData["SoilType"] = new SelectList(Enum.GetNames(typeof(SoilType)));
            ViewData["Color"] = new SelectList(Enum.GetNames(typeof(Color)));
            ViewData["Month"] = new SelectList(Enum.GetNames(typeof(Month)));*/
        }

        // GET: Specie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Species == null)
            {
                return NotFound();
            }

            var specie = await _context.Species.FindAsync(id);
            if (specie == null)
            {
                return NotFound();
            }

            DefineViewData();
            return View(specie);
        }

        // POST: Specie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Genus,Species,Cultivar,Type,CommonNames,Description")] Specie specie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _specieService.UpdateSpecie(specie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecieExists(specie.Id))
                    {
                        return NotFound();
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            DefineViewData();
            return View(specie);
        }

        // GET: Specie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specieById = (await _specieService.GetSpecieById((int)id));
            if (specieById == null)
            {
                return NotFound();
            }
            
            return View(specieById);
        }

        // POST: Specie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Species == null)
            {
                return Problem("Entity set 'ArboretumContext.Species' is null.");
            }
            
            await _specieService.DeleteSpecieById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool SpecieExists(int id)
        {
            /*return (_context.Species?.Any(e => e.SpecieId == id)).GetValueOrDefault();*/
            return false;
        }
    }
}