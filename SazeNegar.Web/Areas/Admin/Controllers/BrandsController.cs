﻿using System;
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
    public class BrandsController : Controller
    {
        private readonly BrandsRepository _repo;
        public BrandsController(BrandsRepository repo)
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
        public ActionResult Create(Brands brands)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(brands);
                return RedirectToAction("Index");
            }

            return View(brands);
        }

        // GET: Admin/ArticleCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brands brands = _repo.Get(id.Value);
            if (brands == null)
            {
                return HttpNotFound();
            }
            return View(brands);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Brands brands)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(brands);
                return RedirectToAction("Index");
            }
            return View(brands);
        }

        // GET: Admin/ArticleCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brands brands = _repo.Get(id.Value);
            if (brands == null)
            {
                return HttpNotFound();
            }
            return PartialView(brands);
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
