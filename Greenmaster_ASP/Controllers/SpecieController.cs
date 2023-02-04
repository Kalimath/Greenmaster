using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Greenmaster_ASP.Models.Arboretum;

namespace Greenmaster_ASP.Controllers
{
    public class SpecieController : Controller
    {
        private readonly ArboretumContext _context;

        public SpecieController(ArboretumContext context)
        {
            _context = context;
        }

        // GET: Specie
        public async Task<IActionResult> Index()
        {
            var arboretumContext = _context.Species.Include(s => s.Dimensions).Include(s => s.FlowerInfo);
            return View(await arboretumContext.ToListAsync());
        }

        // GET: Specie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Species == null)
            {
                return NotFound();
            }

            var specie = await _context.Species
                .Include(s => s.Dimensions)
                .Include(s => s.FlowerInfo)
                .FirstOrDefaultAsync(m => m.SpecieId == id);
            if (specie == null)
            {
                return NotFound();
            }

            return View(specie);
        }

        // GET: Specie/Create
        public IActionResult Create()
        {
            ViewData["SpecieId"] = new SelectList(_context.Dimensions, "DimensionsId", "DimensionsId");
            ViewData["SpecieId"] = new SelectList(_context.FlowerData, "FlowerDataId", "FlowerDataId");
            return View();
        }

        // POST: Specie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpecieId,ScientificName,SunRequirement,WaterRequirement,Lifecycle")] Specie specie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SpecieId"] = new SelectList(_context.Dimensions, "DimensionsId", "DimensionsId", specie.SpecieId);
            ViewData["SpecieId"] = new SelectList(_context.FlowerData, "FlowerDataId", "FlowerDataId", specie.SpecieId);
            return View(specie);
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
            ViewData["SpecieId"] = new SelectList(_context.Dimensions, "DimensionsId", "DimensionsId", specie.SpecieId);
            ViewData["SpecieId"] = new SelectList(_context.FlowerData, "FlowerDataId", "FlowerDataId", specie.SpecieId);
            return View(specie);
        }

        // POST: Specie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpecieId,ScientificName,SunRequirement,WaterRequirement,Lifecycle")] Specie specie)
        {
            if (id != specie.SpecieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecieExists(specie.SpecieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SpecieId"] = new SelectList(_context.Dimensions, "DimensionsId", "DimensionsId", specie.SpecieId);
            ViewData["SpecieId"] = new SelectList(_context.FlowerData, "FlowerDataId", "FlowerDataId", specie.SpecieId);
            return View(specie);
        }

        // GET: Specie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Species == null)
            {
                return NotFound();
            }

            var specie = await _context.Species
                .Include(s => s.Dimensions)
                .Include(s => s.FlowerInfo)
                .FirstOrDefaultAsync(m => m.SpecieId == id);
            if (specie == null)
            {
                return NotFound();
            }

            return View(specie);
        }

        // POST: Specie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Species == null)
            {
                return Problem("Entity set 'ArboretumContext.Species'  is null.");
            }
            var specie = await _context.Species.FindAsync(id);
            if (specie != null)
            {
                _context.Species.Remove(specie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecieExists(int id)
        {
          return (_context.Species?.Any(e => e.SpecieId == id)).GetValueOrDefault();
        }
    }
}
