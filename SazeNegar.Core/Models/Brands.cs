using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace SazeNegar.Core.Models
{

    public class Brands : IBaseEntity
    {
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} باید از 100 کارکتر کمتر باشد")]
        public string BrandName { get; set; }

        public ICollection<Cars> Cars { get; set; }
        [Display(Name = "ویژه")]
        public CarModel CarModel { get; set; }

        public string InsertUser { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }

}

