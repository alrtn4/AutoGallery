﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SazeNegar.Core.Models
{
    public class CarModelCarClass
    {
        public int Id { get; set; }
        //[ForeignKey("CarModel")]
        //public int CarModelId { get; set; }
        public virtual CarModel CarModel { get; set; }
        //[ForeignKey("CarCLass")]
        //public int CarClassId { get; set; }
        public virtual CarClass CarClass { get; set; }
    }
}
