using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project_Canteen_MS.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Name ")]

        public string Address { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Address ")]

        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập PhoneNumber ")]

        public string Image { get; set; }
    }
}