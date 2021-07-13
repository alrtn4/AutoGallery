using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using SazeNegar.Core.Models;
using SazeNegar.Infrastructure;
using SazeNegar.Infrastructure.Repositories;
using SazeNegar.Web.ViewModels;

namespace SazeNegar.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {
        private readonly CarsRepository _repo;
        public CarsController(CarsRepository repo)
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
        public ActionResult Create(Cars cars, HttpPostedFileBase carImage)
        {
            if (ModelState.IsValid)
            {
                #region Upload Image
                if (carImage != null)
                {
                    var newFileName = Guid.NewGuid() + Path.GetExtension(carImage.FileName);
                    carImage.SaveAs(Server.MapPath("~/Files/CarsImages/Image/" + newFileName));

                    cars.Image = newFileName;
                }
                #endregion

                _repo.Add(cars);
                return RedirectToAction("Index");
            }

            return View(cars);
        }

        // GET: Admin/ArticleCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = _repo.Get(id.Value);
            if (cars == null)
            {
                return HttpNotFound();
            }
            return View(cars);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cars cars, HttpPostedFileBase carImage)
        {
            if (ModelState.IsValid)
            {
                #region Upload Image
                if (carImage != null)
                {
                    var newFileName = Guid.NewGuid() + Path.GetExtension(carImage.FileName);
                    carImage.SaveAs(Server.MapPath("~/Files/CarsImages/Image/" + newFileName));

                    cars.Image = newFileName;
                }
                #endregion

                _repo.Update(cars);
                return RedirectToAction("Index");
            }
            return View(cars);
        }

        // GET: Admin/ArticleCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = _repo.Get(id.Value);
            if (cars == null)
            {
                return HttpNotFound();
            }
            return PartialView(cars);
        }

        // POST: Admin/ArticleCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }

        //GET
        public ActionResult CarBrands(int carId)
        {
            var user = _repo.GetCar(carId);
            ViewBag.CarID = carId;

            var db = new MyDbContext();
            var _logsRepository = new LogsRepository(db);
            var _brandsRepo = new BrandsRepository(db, _logsRepository);
            CarBrandsViewModel brandList = new CarBrandsViewModel();
            brandList.CarBrandsList = _brandsRepo.GetAll();

            return View(brandList);
        }

        ////POST
        //[HttpPost]
        //public ActionResult CarBrands(string userId, string[] selectedRoles)
        //{

        //    if (selectedRoles == null)
        //    {
        //        return RedirectToAction("UserRoles", new { userId });
        //    }
        //    List<string> seletRoleIds = new List<string>();
        //    seletRoleIds.AddRange(selectedRoles);
        //    foreach (var role in _repo.GetRoles())
        //    {
        //        #region Add Role if is in selectRoles and is not in UserRoles

        //        if (seletRoleIds.Contains(role.Id) && !_repo.UserHasRole(userId, role.Id))
        //        {
        //            _repo.AddUserRole(userId, role.Id);
        //        }
        //        #endregion

        //        #region Delete Role if is in UserRoles  and is not in selectRoles
        //        if (!seletRoleIds.Contains(role.Id) && _repo.UserHasRole(userId, role.Id))
        //        {
        //            UserRole uRole = _repo.GetUserRole(userId, role.Id);
        //            _repo.DeleteUserRole(uRole);
        //        }
        //        #endregion
        //    }

        //    return RedirectToAction("Index");
        //}

    }
}
