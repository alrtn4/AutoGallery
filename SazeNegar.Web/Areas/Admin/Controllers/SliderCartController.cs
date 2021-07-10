using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SazeNegar.Core.Models;
using SazeNegar.Core.Utility;
using SazeNegar.Infrastructure;
using SazeNegar.Infrastructure.Helpers;
using SazeNegar.Infrastructure.Repositories;
using SazeNegar.Web.ViewModels;

namespace SazeNegar.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class SliderCartController : Controller
    {
        private readonly CartRepository _repo;
        public SliderCartController(CartRepository repo)
        {
            _repo = repo;
        }
        // GET: Admin/StaticContentDetails
        public ActionResult Index()
        {
            var content = _repo.GetCarts();
            content = content.OrderByDescending(c => c.Id).ToList();
            return View(content);
        }
        // GET: Admin/StaticContentDetails/Create
        public ActionResult Create()
        {
            //ViewBag.StaticContentTypeId = (int)StaticContentTypes.Slider;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public ActionResult Create(Cart cart, HttpPostedFileBase sliderCartImage)
=======
        public ActionResult Create(StaticContentDetail staticContentDetail, HttpPostedFileBase StaticContentDetailImage)
>>>>>>> master
        {
            if (ModelState.IsValid)
            {
                #region Upload Image
<<<<<<< HEAD
                if (sliderCartImage != null)
                {
                    // Saving Temp Image
                    var newFileName = Guid.NewGuid() + Path.GetExtension(sliderCartImage.FileName);
                    sliderCartImage.SaveAs(Server.MapPath("~/Files/SliderCart/Images/" + newFileName));

                    // Resizing Image
                    //ImageResizer image = new ImageResizer();
                    //if (staticContentDetail.StaticContentTypeId == (int)StaticContentTypes.Slider || staticContentDetail.StaticContentTypeId == (int)StaticContentTypes.BlogImage)
=======
                if (StaticContentDetailImage != null)
                {
                    // Saving Temp Image
                    var newFileName = Guid.NewGuid() + Path.GetExtension(StaticContentDetailImage.FileName);
                    StaticContentDetailImage.SaveAs(Server.MapPath("/Files/StaticContentImages/Temp/" + newFileName));

                    // Resizing Image
                    ImageResizer image = new ImageResizer();
                    if (staticContentDetail.StaticContentTypeId == (int)StaticContentTypes.Slider || staticContentDetail.StaticContentTypeId == (int)StaticContentTypes.BlogImage)
                        image = new ImageResizer(1020, 700, true);
                    if (staticContentDetail.StaticContentTypeId == (int)StaticContentTypes.CompanyHistory)
                        image = new ImageResizer(1000, 1000, true);

                    image.Resize(Server.MapPath("/Files/StaticContentImages/Temp/" + newFileName),
                        Server.MapPath("/Files/StaticContentImages/Image/" + newFileName));

                    // Deleting Temp Image
                    System.IO.File.Delete(Server.MapPath("/Files/StaticContentImages/Temp/" + newFileName));

                    staticContentDetail.Image = newFileName;
                }
                #endregion
                _repo.Add(staticContentDetail);

                return RedirectToAction("Index");
            }
            ViewBag.StaticContentTypeId = (int)StaticContentTypes.Slider;
            return View(staticContentDetail);
        }

        public ActionResult CreateBanner()
        {
            ViewBag.StaticContentTypeId = (int)StaticContentTypes.Banner;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBanner(StaticContentDetail staticContentDetail, HttpPostedFileBase StaticContentDetailImage)
        {
            if (ModelState.IsValid)
            {
                #region Upload Image
                if (StaticContentDetailImage != null)
                {
                    // Saving Temp Image
                    var newFileName = Guid.NewGuid() + Path.GetExtension(StaticContentDetailImage.FileName);
                    //StaticContentDetailImage.SaveAs(Server.MapPath("~/Files/StaticContentImages/Temp/" + newFileName));

                    // Resizing Image
                    //ImageResizer image = new ImageResizer();
                    //if (staticContentDetail.StaticContentTypeId == (int)StaticContentTypes.Banner || staticContentDetail.StaticContentTypeId == (int)StaticContentTypes.Slider || staticContentDetail.StaticContentTypeId == (int)StaticContentTypes.BlogImage)
>>>>>>> master
                    //    image = new ImageResizer(1020, 700, true);
                    //if (staticContentDetail.StaticContentTypeId == (int)StaticContentTypes.CompanyHistory)
                    //    image = new ImageResizer(1000, 1000, true);

<<<<<<< HEAD
                    //image.Resize(Server.MapPath("/Files/StaticContentImages/Temp/" + newFileName),
                    //    Server.MapPath("/Files/StaticContentImages/Image/" + newFileName));

                    //// Deleting Temp Image
                    //System.IO.File.Delete(Server.MapPath("/Files/StaticContentImages/Temp/" + newFileName));

                    cart.Image = newFileName;
                }
                #endregion
                _repo.Add(cart);

                return RedirectToAction("Index");
            }
            return View(cart);
        }

        //public ActionResult CreateBanner()
        //{
        //    ViewBag.StaticContentTypeId = (int)StaticContentTypes.Banner;
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateBanner(StaticContentDetail staticContentDetail, HttpPostedFileBase StaticContentDetailImage)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        #region Upload Image
        //        if (StaticContentDetailImage != null)
        //        {
        //            // Saving Temp Image
        //            var newFileName = Guid.NewGuid() + Path.GetExtension(StaticContentDetailImage.FileName);
        //            //StaticContentDetailImage.SaveAs(Server.MapPath("~/Files/StaticContentImages/Temp/" + newFileName));

        //            // Resizing Image
        //            //ImageResizer image = new ImageResizer();
        //            //if (staticContentDetail.StaticContentTypeId == (int)StaticContentTypes.Banner || staticContentDetail.StaticContentTypeId == (int)StaticContentTypes.Slider || staticContentDetail.StaticContentTypeId == (int)StaticContentTypes.BlogImage)
        //            //    image = new ImageResizer(1020, 700, true);
        //            //if (staticContentDetail.StaticContentTypeId == (int)StaticContentTypes.CompanyHistory)
        //            //    image = new ImageResizer(1000, 1000, true);

        //            //image.Resize(Server.MapPath("~/Files/StaticContentImages/Temp/" + newFileName),
        //            //    Server.MapPath("~/Files/StaticContentImages/Image/" + newFileName));

        //            // Deleting Temp Image
        //            //System.IO.File.Delete(Server.MapPath("~/Files/StaticContentImages/Temp/" + newFileName));
        //            StaticContentDetailImage.SaveAs(Server.MapPath("~/Files/StaticContentImages/Image/" + newFileName));

        //            staticContentDetail.Image = newFileName;
        //        }
        //        #endregion
        //        _repo.Add(staticContentDetail);

        //        return RedirectToAction("Index");
        //    }

        //    return View(staticContentDetail);
        //}

        //GET: Admin/StaticContentDetails/Edit/5
=======
                    //image.Resize(Server.MapPath("~/Files/StaticContentImages/Temp/" + newFileName),
                    //    Server.MapPath("~/Files/StaticContentImages/Image/" + newFileName));

                    // Deleting Temp Image
                    //System.IO.File.Delete(Server.MapPath("~/Files/StaticContentImages/Temp/" + newFileName));
                    StaticContentDetailImage.SaveAs(Server.MapPath("~/Files/StaticContentImages/Image/" + newFileName));

                    staticContentDetail.Image = newFileName;
                }
                #endregion
                _repo.Add(staticContentDetail);

                return RedirectToAction("Index");
            }

            return View(staticContentDetail);
        }

        // GET: Admin/StaticContentDetails/Edit/5
>>>>>>> master
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
<<<<<<< HEAD
            Cart cart = _repo.GetCart(id.Value);
            if (cart == null)
            {
                return HttpNotFound();
            }
            //ViewBag.cart = new SelectList(_repo.GetStaticContentTypes(), "Id", "Name", staticContentDetail.StaticContentTypeId);
            return View(cart);
=======
            StaticContentDetail staticContentDetail = _repo.GetStaticContentDetail(id.Value);
            if (staticContentDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.StaticContentTypeId = new SelectList(_repo.GetStaticContentTypes(), "Id", "Name", staticContentDetail.StaticContentTypeId);
            return View(staticContentDetail);
>>>>>>> master
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public ActionResult Edit(Cart cart, HttpPostedFileBase sliderCartImage)
=======
        public ActionResult Edit(StaticContentDetail staticContentDetail, HttpPostedFileBase StaticContentDetailImage)
>>>>>>> master
        {
            if (ModelState.IsValid)
            {
                #region Upload Image
<<<<<<< HEAD
                if (sliderCartImage != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("/Files/SliderCartImage/Image/" + cart.Image)))
                        System.IO.File.Delete(Server.MapPath("/Files/SliderCartImage/Image/" + cart.Image));

                    // Saving Temp Image
                    var newFileName = Guid.NewGuid() + Path.GetExtension(sliderCartImage.FileName);
                    sliderCartImage.SaveAs(Server.MapPath("/Files/SliderCartImage/Image/" + newFileName));

                    //// Resizing Image
                    //ImageResizer image = new ImageResizer();
                    //if (staticContentDetail.StaticContentTypeId == (int)StaticContentTypes.Slider || staticContentDetail.StaticContentTypeId == (int)StaticContentTypes.BlogImage)
                    //    image = new ImageResizer(1020, 700, true);
                    //if (staticContentDetail.StaticContentTypeId == (int)StaticContentTypes.CompanyHistory)
                    //    image = new ImageResizer(1000, 1000, true);

                    //image.Resize(Server.MapPath("/Files/StaticContentImages/Temp/" + newFileName),
                    //    Server.MapPath("/Files/StaticContentImages/Image/" + newFileName));

                    //// Deleting Temp Image
                    //System.IO.File.Delete(Server.MapPath("/Files/StaticContentImages/Temp/" + newFileName));

                    cart.Image = newFileName;
                }
                #endregion

                _repo.Update(cart);
                return RedirectToAction("Index");
            }
            //ViewBag.StaticContentTypeId = new SelectList(_repo.GetStaticContentTypes(), "Id", "Name", staticContentDetail.StaticContentTypeId);
            return View(cart);
        }
        //// GET: Admin/StaticContentDetails/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    StaticContentDetail staticContentDetail = _repo.GetStaticContentDetail(id.Value);
        //    if (staticContentDetail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return PartialView(staticContentDetail);
        //}

        //// POST: Admin/StaticContentDetails/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    var staticContentDetail = _repo.Get(id);

        //    //#region Delete StaticContentDetail Image
        //    //if (staticContentDetail.Image != null)
        //    //{
        //    //    if (System.IO.File.Exists(Server.MapPath("/Files/StaticContentImages/Image/" + staticContentDetail.Image)))
        //    //        System.IO.File.Delete(Server.MapPath("/Files/StaticContentImages/Image/" + staticContentDetail.Image));

        //    //    if (System.IO.File.Exists(Server.MapPath("/Files/StaticContentImages/Thumb/" + staticContentDetail.Image)))
        //    //        System.IO.File.Delete(Server.MapPath("/Files/StaticContentImages/Thumb/" + staticContentDetail.Image));
        //    //}
        //    //#endregion

        //    _repo.Delete(id);
        //    return RedirectToAction("Index");
        //}
=======
                if (StaticContentDetailImage != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("/Files/StaticContentImages/Image/" + staticContentDetail.Image)))
                        System.IO.File.Delete(Server.MapPath("/Files/StaticContentImages/Image/" + staticContentDetail.Image));

                    // Saving Temp Image
                    var newFileName = Guid.NewGuid() + Path.GetExtension(StaticContentDetailImage.FileName);
                    StaticContentDetailImage.SaveAs(Server.MapPath("/Files/StaticContentImages/Temp/" + newFileName));

                    // Resizing Image
                    ImageResizer image = new ImageResizer();
                    if (staticContentDetail.StaticContentTypeId == (int)StaticContentTypes.Slider || staticContentDetail.StaticContentTypeId == (int)StaticContentTypes.BlogImage)
                        image = new ImageResizer(1020, 700, true);
                    if (staticContentDetail.StaticContentTypeId == (int)StaticContentTypes.CompanyHistory)
                        image = new ImageResizer(1000, 1000, true);

                    image.Resize(Server.MapPath("/Files/StaticContentImages/Temp/" + newFileName),
                        Server.MapPath("/Files/StaticContentImages/Image/" + newFileName));

                    // Deleting Temp Image
                    System.IO.File.Delete(Server.MapPath("/Files/StaticContentImages/Temp/" + newFileName));

                    staticContentDetail.Image = newFileName;
                }
                #endregion

                _repo.Update(staticContentDetail);
                return RedirectToAction("Index");
            }
            ViewBag.StaticContentTypeId = new SelectList(_repo.GetStaticContentTypes(), "Id", "Name", staticContentDetail.StaticContentTypeId);
            return View(staticContentDetail);
        }
        // GET: Admin/StaticContentDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaticContentDetail staticContentDetail = _repo.GetStaticContentDetail(id.Value);
            if (staticContentDetail == null)
            {
                return HttpNotFound();
            }
            return PartialView(staticContentDetail);
        }

        // POST: Admin/StaticContentDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var staticContentDetail = _repo.Get(id);

            //#region Delete StaticContentDetail Image
            //if (staticContentDetail.Image != null)
            //{
            //    if (System.IO.File.Exists(Server.MapPath("/Files/StaticContentImages/Image/" + staticContentDetail.Image)))
            //        System.IO.File.Delete(Server.MapPath("/Files/StaticContentImages/Image/" + staticContentDetail.Image));

            //    if (System.IO.File.Exists(Server.MapPath("/Files/StaticContentImages/Thumb/" + staticContentDetail.Image)))
            //        System.IO.File.Delete(Server.MapPath("/Files/StaticContentImages/Thumb/" + staticContentDetail.Image));
            //}
            //#endregion

            _repo.Delete(id);
            return RedirectToAction("Index");
        }
>>>>>>> master
    }
}
