using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Project_Canteen_MS.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Name ")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Quantity ")]

        public int Quantity { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Price ")]

        public int Price { get; set; }

        public int PromotionPrice { get; set; }

        public string Image { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public int BrandID { get; set; }
        public virtual Brand Brand { get; set; }
    }
}