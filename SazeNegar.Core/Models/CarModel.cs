using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Web.Mvc;

namespace SazeNegar.Core.Models
{

    public class CarModel : IBaseEntity
    {
        public int Id { get; set; }
        [Display(Name = "مدل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} باید از 100 کارکتر کمتر باشد")]
        public string Model { get; set; }

        public  int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public virtual Brands Brand { get; set; }
        public virtual ICollection<CarModelCarClass> CarModelCarClasses { get; set; }

        public string InsertUser { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }

    }

}