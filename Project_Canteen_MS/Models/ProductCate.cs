using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Project_Canteen_MS.Models
{
    public class ProductCate
    {
        DataContext db = new DataContext();
        public ProductCate()
        {
            db = new DataContext();
        }

        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }
        public Category ViewDetail(long id)
        {
            return db.Categories.Find(id);
        }
        public List<Product> ListByCategoryId(long cateId)
        {
            return db.Products.Where(x => x.CategoryID == cateId).ToList();
        }

    }
}