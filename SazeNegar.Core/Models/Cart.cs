using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace SazeNegar.Core.Models
{
<<<<<<< HEAD
    public class Cart : IBaseEntity
=======
   public class Cart : IBaseEntity
>>>>>>> master
    {
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(600, ErrorMessage = "{0} باید از 600 کارکتر کمتر باشد")]
        public string Title { get; set; }
        [Display(Name = "ویژه")]
<<<<<<< HEAD
        public string Special { get; set; }
=======
        public bool Special { get; set; }
>>>>>>> master
        [Display(Name = "تگ")]
        public string Tag { get; set; }
        [Display(Name = "تصویر")]
        public string Image { get; set; }
        [Display(Name = "قیمت")]
        public string Price { get; set; }
        [Display(Name = "برند")]
        public string Brand { get; set; }
        [Display(Name = "دنده")]
<<<<<<< HEAD
        public string Gear { get; set; }
        [Display(Name = "سانروف")]
        public string Sunroof { get; set; }
        [Display(Name = "راهبری")]
        public string Navigation { get; set; }
=======
        public bool Gear { get; set; }
        [Display(Name = "سانروف")]
        public bool Sunroof { get; set; }
        [Display(Name = "راهبری")]
        public bool Navigation { get; set; }
>>>>>>> master
        [Display(Name = "تاریخ")]
        public int Date { get; set; }
        [Display(Name = "لینک")]
        public string Link { get; set; }

        public string InsertUser { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> master
