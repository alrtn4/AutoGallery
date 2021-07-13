using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SazeNegar.Core.Models;

namespace SazeNegar.Web.ViewModels
{
    public class CarBrandsViewModel 
    {
        public List<Brands> CarBrandsList { get; set; }
        //public IEnumerator<Brands> GetEnumerator()
        //{
        //    IEnumerator<Brands> IE = (IEnumerator<Brands>)CarBrandsList;
        //    return IE;
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}
    }
}
