using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Project_Canteen_MS.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("CANTEEN")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Product> Products { get; set; }
     
        public System.Data.Entity.DbSet<Project_Canteen_MS.Models.Staff> Staffs { get; set; }
        public System.Data.Entity.DbSet<Project_Canteen_MS.Models.Bill> Bills { get; set; }
        public System.Data.Entity.DbSet<Project_Canteen_MS.Models.Slide> Slides { get; set; }
        public System.Data.Entity.DbSet<Project_Canteen_MS.Models.About> Abouts { get; set; }
        public System.Data.Entity.DbSet<Project_Canteen_MS.Models.Customer> Customers { get; set; }
    }

}