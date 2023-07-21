using Greenmaster.Core.Mappers;
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
        private readonly IViewModelMapper<Rendering, RenderingViewModel> _renderingMapper;

        public RenderingController(IRenderingService renderingService,
            IViewModelMapper<Rendering, RenderingViewModel> renderingMapper)
        {
            _modelService = renderingService ?? throw new ArgumentNullException(nameof(renderingService));
            _renderingMapper = renderingMapper;
        }

        // GET: Specie
        public Task<IActionResult> Index()
        {
            return Task.FromResult<IActionResult>(View());
        }

        public async Task<JsonResult> GetRenderings()
        {
            var renderings = (await _modelService.GetAll());
            var viewModels = renderings.Select(rendering => _renderingMapper.ToViewModel(rendering)).ToList();
            return Json(new { data = viewModels });
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

            return View(_renderingMapper.ToViewModel(rendering));
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
                var rendering = await _renderingMapper.ToModel(renderingViewModel);
                await _modelService.Add(rendering);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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
            return View(new RenderingViewModel(){Id= id});
        }

        // POST: Rendering/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id, IFormCollection collection)
        {
            try
            {
                if (!await _modelService.ExistsWithId(id))
                    return NotFound();

                await _modelService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch( Exception e )
            {
                Console.WriteLine(e);
                return new BadRequestResult();
            }
        }

        private void DefineViewData()
        {
            ViewData["Season"] = new SelectList(Enum.GetNames(typeof(Season)));
            ViewData["Type"] = new SelectList(Enum.GetNames(typeof(RenderingObjectType)));
        }
    }
}