using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AutoGallery.Models;

namespace AutoGallery
{
    public class MyDbContext : DbContext
    {

        public MyDbContext() : base("DefaultConnection")
        {

        }

        public DbSet<BannerImage> BannerImages { get; set; }
    }
}