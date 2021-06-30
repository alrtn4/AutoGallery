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
        private readonly BannerImageRepository _repo;
        public HomeController(BannerImageRepository repo)
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
            BannerImage bannerImage;
            var image = _repo.GetBannerImage();
            bannerImage = image;
            return View(bannerImage);
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BannerImage banImage, HttpPostedFileBase image)
        {
            var fileName = Path.GetFileName(image.FileName);
            banImage.bannerImage = fileName;
            _repo.AddBannerImage(banImage);
            image.SaveAs(Server.MapPath("/Files/images/" + fileName));
            
            return View();
        }

        // GET: Default/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

    }
}
