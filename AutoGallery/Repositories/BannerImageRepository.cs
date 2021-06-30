using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoGallery.Models;

namespace AutoGallery.Repositories
{
    public class BannerImageRepository 
    {
        private readonly MyDbContext _context;

        
        public BannerImageRepository(MyDbContext context)
        {
            _context = context;
        }
        public BannerImage GetBannerImage()
        {
            return _context.BannerImages.OrderByDescending(a => a.Id).FirstOrDefault();
        }

        public void AddBannerImage(BannerImage bannerImage)
        {
            _context.BannerImages.Add(bannerImage);

            _context.SaveChanges();
        }

    }
}