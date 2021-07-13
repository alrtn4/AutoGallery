using System;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SazeNegar.Core.Models;
using SazeNegar.Infrastructure;
using SazeNegar.Infrastructure.Repositories;

namespace SazeNegar.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class CarModelController : Controller
    {
        private readonly CarModelRepository _repo;
        public CarModelController(CarModelRepository repo)
        {
            _repo = repo;
        }
        // GET: Admin/ArticleCategories
        public ActionResult Index()
        {
            return View(_repo.GetAll());
        }

        // GET: Admin/ArticleCategories/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(carModel);
                return RedirectToAction("Index");
            }

            return View(carModel);
        }

        // GET: Admin/ArticleCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = _repo.Get(id.Value);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return View(carModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(carModel);
                return RedirectToAction("Index");
            }
            return View(carModel);
        }

        // GET: Admin/ArticleCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = _repo.Get(id.Value);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return PartialView(carModel);
        }

        // POST: Admin/ArticleCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
