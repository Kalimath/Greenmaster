using Greenmaster.Core.Factories;
using Greenmaster.Core.Models;
using Greenmaster.Core.Models.ViewModels;
using Greenmaster.Core.Services.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StaticData.Object.Rendering;
using StaticData.Time.Durations;

namespace Greenmaster.AdminPortal.Controllers
{
    public class RenderingController : Controller
    {
        private readonly IRenderingService _modelService;
        private readonly IModelFactory<Rendering, RenderingViewModel> _renderingFactory;

        public RenderingController(IRenderingService renderingService, IModelFactory<Rendering, RenderingViewModel> renderingFactory)
        {
            _modelService = renderingService ?? throw new ArgumentNullException(nameof(renderingService));
            _renderingFactory = renderingFactory;
        }
        
        // GET: Specie
        public Task<IActionResult> Index()
        {
            return Task.FromResult<IActionResult>(View());
        }
        
        public async Task<JsonResult> GetRenderings()
        {
            var renderings = (await _modelService.GetAll());
            var viewModels = renderings.Select(rendering => _renderingFactory.ToViewModel(rendering)).ToList();
            return Json(new { data = viewModels});
        }

        // GET: Rendering/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rendering rendering;
            try
            {
                rendering = await _modelService.GetById((int)id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }

            return View(_renderingFactory.ToViewModel(rendering));
        }

        // GET: Rendering/Create
        public IActionResult Create()
        {
            DefineViewData();
            return View();
        }

        // POST: Rendering/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RenderingViewModel renderingViewModel)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException($"Invalid {nameof(ModelState)}");
                var rendering = await _renderingFactory.Create(renderingViewModel);
                await _modelService.Add(rendering);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                DefineViewData();
                return View(renderingViewModel);
            }
        }

        // GET: Rendering/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rendering/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Rendering/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rendering/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
        private void DefineViewData()
        {
            ViewData["Season"] = new SelectList(Enum.GetNames(typeof(Season)));
            ViewData["Type"] = new SelectList(Enum.GetNames(typeof(RenderingObjectType)));
        }
    }
}