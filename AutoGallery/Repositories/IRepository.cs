using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoGallery.Models;

namespace AutoGallery.Repositories
{
    public interface IRepository
    {
        void AddBannerImage(BannerImage bannerImage);

        BannerImage GetBannerImage(int id);
           
        
    }
}
