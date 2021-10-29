using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Canteen_MS.Models;
using System.IO;
using System.Dynamic;
namespace Project_Canteen_MS.Controllers
{
    public class WebController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Web
        public ActionResult Index()
        {
            dynamic data = new ExpandoObject();
            data.Slides = db.Slides.ToList();
            data.Products = db.Products.ToList();
            return View(data);
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Shop()
        {
            return View();
        }
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCate().ListAll();
            return PartialView(model);
        }
        public ActionResult Category(long id)
        {
            var cate = new ProductCate().ViewDetail(id);
            return View(cate);
        }
    }
 }