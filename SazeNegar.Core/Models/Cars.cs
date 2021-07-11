using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace SazeNegar.Core.Models
{

    public class Cars : IBaseEntity
    {
        public int Id { get; set; }
        [Display(Name = "تصویر")]
        public string Image { get; set; }
        [Display(Name = "تاریخ")]
        public int Date { get; set; }
        [Display(Name = "لینک")]
        public string Link { get; set; }

        [Display(Name = "برند")]
        public Brands Brand { get; set; }

        public string InsertUser { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }

}

