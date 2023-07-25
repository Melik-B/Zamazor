using Business.Enums;
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Zamazor.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StoresController : Controller
    {
        private readonly IStoreService _storeService;

        public StoresController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        // GET: Stores
        public ActionResult Index()
        {
            var model = _storeService.Query().ToList();
            return View(model);
        }

        // GET: Stores/Details/5
        public ActionResult Details(int id)
        {
            var model = _storeService.Query().SingleOrDefault(m => m.Id == id);
            return View(model);
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StoreModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _storeService.Add(model);
                if (result.IsSuccessful)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", result.Message);
            }
            return View(model);
        }

        // GET: Stores/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _storeService.Query().SingleOrDefault(m => m.Id == id);
            return View(model);
        }

        // POST: Stores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StoreModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _storeService.Update(model);
                if (result.IsSuccessful)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", result.Message);
            }
            return View(model);
        }

        // GET: Stores/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _storeService.Query().SingleOrDefault(m => m.Id == id);
            return View(model);
        }

        // POST: Stores/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _storeService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
