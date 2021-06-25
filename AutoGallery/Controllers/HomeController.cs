using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoGallery.Models;
using AutoGallery.Repositories;
using System.IO;

namespace AutoGallery.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repo;
        public HomeController(IRepository repo)
        {
            _repo = repo;
        }

        public HomeController()
        {
            _repo = new BannerImageRepository(new MyDbContext());
        }

        // GET: Default
        public ActionResult Index()
        {
            BannerImage bannerImage = new BannerImage();
            var image = _repo.GetBannerImage(1).bannerImage;
            bannerImage.bannerImage = image;
            return View(bannerImage);
        }

        // GET: Default/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //GET: Default/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BannerImage banImage, HttpPostedFileBase image)
        {
            //if (ModelState.IsValid)
            //{
            //    #region Upload Image
            //   if (ArticleImage != null)
            //    {
            //        if (System.IO.File.Exists(Server.MapPath("/Files/ArticleImages/Image/" + article.Image)))
            //            System.IO.File.Delete(Server.MapPath("/Files/ArticleImages/Image/" + article.Image));

            //if (System.IO.File.Exists(Server.MapPath("/Files/ArticleImages/Thumb/" + article.Image)))
            //           System.IO.File.Delete(Server.MapPath("/Files/ArticleImages/Thumb/" + article.Image));

            //Saving Temp Image
            //     var newFileName = Guid.NewGuid() + Path.GetExtension(ArticleImage.FileName);
            //       ArticleImage.SaveAs(Server.MapPath("/Files/ArticleImages/Temp/" + newFileName));
            //       Resize Image
            //        ImageResizer image = new ImageResizer(1000, 600, true);
            //        image.Resize(Server.MapPath("/Files/ArticleImages/Temp/" + newFileName);
            //            Server.MapPath("/Files/ArticleImages/Image/" + newFileName));

            //       ImageResizer thumb = new ImageResizer(1000, 600, true);
            //       thumb.Resize(Server.MapPath("/Files/ArticleImages/Temp/" + newFileName),
            //            Server.MapPath("/Files/ArticleImages/Thumb/" + newFileName));

            //        Deleting Temp Image
            //        System.IO.File.Delete(Server.MapPath("/Files/ArticleImages/Temp/" + newFileName));

            //       bannerImage.bannerImage = image;
            //    }
            ////#endregion

            var fileName = Path.GetFileName(image.FileName);
            banImage.bannerImage = fileName;
            _repo.AddBannerImage(banImage);
            image.SaveAs(Server.MapPath("/Files/images/" + fileName));

            //if (!string.IsNullOrEmpty(Tags))
            //    _repo.AddArticleTags(article.Id, Tags);

            //return RedirectToAction("Index");
            ////}
            //ViewBag.Tags = Tags;
            //ViewBag.ArticleCategoryId = new SelectList(_repo.GetArticleCategories(), "Id", "Title", article.ArticleCategoryId);
            return View(banImage);
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try// POST: Default/Edit/5
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
