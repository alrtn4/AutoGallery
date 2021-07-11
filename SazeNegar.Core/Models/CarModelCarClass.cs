using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SazeNegar.Core.Models
{
    public class CarModelCarClass
    {
        public int Id { get; set; }
        public CarModel CarModel { get; set; }
        public CarClass CarClass { get; set; }
    }
}
