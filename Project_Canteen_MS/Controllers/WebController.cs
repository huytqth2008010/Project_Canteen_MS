using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Canteen_MS.Models;
using System.IO;
using System.Dynamic;
using System.Net;
using PagedList;
using X.PagedList;
namespace Project_Canteen_MS.Controllers
{
    public class WebController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Web
        public ActionResult Index(int? page)
        {
            var pageNumber = page ?? 1; // if no page is specified, default to the first page (1)
            int pageSize = 25; // Get 25 students for each requested page.
            dynamic data = new ExpandoObject();
            data.Slides = db.Slides.ToList();
            data.Products = db.Products.Where(x => x.Id <= 6).ToList();
            data.Products1 = db.Products.Where(x => x.PromotionPrice >= 1).ToList() ;
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
            var category = new ProductCate().ViewDetail(id);
            ViewBag.Category = category;
            var model = new ProductCate().ListByCategoryId(id).ToList();
            return View(model);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        public ActionResult AddToCart(int? id, int qty)
        {
            if (id == null) return HttpNotFound();
            try
            {
                Product p = db.Products.Find(id);
                if (p == null) return HttpNotFound();
                // them vao gio hang
                CartItem item = new CartItem() { Product = p, Qty = qty };
                Cart cart = (Cart)Session["Cart"];
                if (cart == null)
                {
                    cart = new Cart();
                }
                cart.AddToCart(item);
                Session["Cart"] = cart; // them session
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return RedirectToAction("Cart");
        }

        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult RemoveItem(int? id)
        {
            try
            {
                var cart = Session["Cart"] as Cart;
                if (cart == null) return RedirectToAction("Cart");
                cart.RemoveItem((int)id);
                Session["Cart"] = cart;

            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Cart");
        }
        public ActionResult Update(FormCollection fc)
        {
           
            return View();
        }
        public ActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckOut(Order order)
        {
            if (ModelState.IsValid)
            {
                var cart = (Cart)Session["cart"];
                order.GrandTotal = cart.GrandTotal;
                order.CreatedAt = DateTime.Now;
                order.Status = 1;
                db.Orders.Add(order);
                db.SaveChanges();

                foreach (var item in cart.CartItems)
                {
                    OrderItem orderItem = new OrderItem() { OrderID = order.Id, ProductID = item.Product.Id, Qty = item.Qty, Price = item.Product.Price };
                    db.OrderItems.Add(orderItem);
                }
                db.SaveChanges();
                Session["cart"] = null;// xoa gio hang
            }

            return RedirectToAction("Index");
        }
    }
 }