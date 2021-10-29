using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Project_Canteen_MS.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Name")]

        public string Name { get; set; }
        public virtual ICollection<Brand> Brands { get; set; }
    }
}