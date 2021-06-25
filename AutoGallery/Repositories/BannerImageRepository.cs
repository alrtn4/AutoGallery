using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoGallery.Models;

namespace AutoGallery.Repositories
{
    public class BannerImageRepository : IRepository
    {
        private readonly MyDbContext _context;

        //public BannerImageRepository()
        //{

        //}
        public BannerImageRepository(MyDbContext context)
        {
            _context = context;
        }
        public BannerImage GetBannerImage(int id)
        {
            return _context.BannerImages.FirstOrDefault(a => a.Id == id);
        }

        public void AddBannerImage(BannerImage bannerImage)
        {
            _context.BannerImages.Add(bannerImage);

            _context.SaveChanges();
        }

    }
}