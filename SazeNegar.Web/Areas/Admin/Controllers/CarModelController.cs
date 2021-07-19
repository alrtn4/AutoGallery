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
    public class CarModelController : Controller
    {
        private readonly CarModelRepository _repo;
        private readonly MyDbContext db; 
        public CarModelController(CarModelRepository repo, MyDbContext myDbContext)
        {
            _repo = repo;
            db = myDbContext;
        }
        // GET: Admin/ArticleCategories
        public ActionResult Index()
        {
            return View(_repo.GetAll());
        }

        public ActionResult CarModelCarClass(string carClassId)
        {
            #region Create Role Permissions

            List<CarModelCarClassViewModel> CarModelCarCLasses = new List<CarModelCarClassViewModel>();
            foreach (var item in db.CarClasses.ToList())
            {
                CarModelCarClassViewModel carModelCarClassViewModel = new CarModelCarClassViewModel()
                {
                    PermissionID = item.Id,
                    PermissionTitle = item.Title,
                    ControllerName = item.ControllerName,
                    Access = db.RolePermissions
                        .Where(a => a.RoleId == roleId && a.PermissionId == item.Id).Any()
                };
                rolePermissions.Add(permission);
            }

            #endregion

            ViewBag.RoleName = db.Roles.Find(roleId).Name;
            ViewBag.RoleID = roleId;

            ViewBag.TreeItems = rolePermissions.OrderBy(a => a.PermissionTitle).Select(r => new TreeViewItemModel()
            {
                Text = r.PermissionTitle,
                Id = r.PermissionID.ToString(),
                Checked = r.Access
            }).ToList();

            return View(rolePermissions);
        }



        [HttpPost]
        public ActionResult CarModelCarClass(string roleId, string[] selectedPermissions)
        {

            if (selectedPermissions == null)
            {
                return RedirectToAction("RolePermission", new { roleId });
            }

            List<int> selectPermissions = new List<int>();
            selectPermissions.AddRange(selectedPermissions.Select(ro => Convert.ToInt32(ro)));

            foreach (var permit in db.Permissions.ToList())
            {
                #region Add permission if is in selectedPermissions and is not in RolePermissions

                if (selectPermissions.Contains(permit.Id) && !db.RolePermissions
                        .Where(a => a.RoleId == roleId && a.PermissionId == permit.Id).Any())
                {
                    RolePermission rPermit = new RolePermission()
                    {
                        RoleId = roleId,
                        PermissionId = permit.Id
                    };
                    db.RolePermissions.Add(rPermit);
                    db.SaveChanges();
                }

                #endregion

                #region Delete Role if is in UserRoles  and is not in selectRoles

                if (!selectPermissions.Contains(permit.Id) && db.RolePermissions
                        .Where(a => a.RoleId == roleId && a.PermissionId == permit.Id).Any())
                {
                    RolePermission rPermision = db.RolePermissions
                        .Where(a => a.RoleId == roleId && a.PermissionId == permit.Id).FirstOrDefault();
                    db.RolePermissions.Remove(rPermision);
                    db.SaveChanges();
                }

                #endregion
            }

            return RedirectToAction("Index");
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
