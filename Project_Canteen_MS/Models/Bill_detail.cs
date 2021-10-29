using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Canteen_MS.Models
{
    public class Bill_detail
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

    }
}