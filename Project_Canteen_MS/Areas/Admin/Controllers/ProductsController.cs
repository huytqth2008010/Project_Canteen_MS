using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_Canteen_MS.Models;
using System.IO;
namespace Project_Canteen_MS.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Products
        [Authorize]
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Brand).Include(p => p.Category);
            return View(products.ToList());
        }

        // GET: Products/Details/5
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

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.BrandID = new SelectList(db.Brands, "Id", "Name");
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Quantity,Price,Image,CategoryID,BrandID")] Product product, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                string catImg = "~/Uploads/default.png"; //edit -  product.Image
                try
                {
                    if (Image != null)
                    {
                        string fileName = Path.GetFileName(Image.FileName);// lay url path khi upload len
                        string path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                        Image.SaveAs(path);
                        catImg = "~/Uploads/" + fileName;
                    }

                }
                catch (Exception e)
                {
                }
                finally
                {
                    product.Image = catImg;// set giá trị sau khi upload ảnh lên vào product
                }
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandID = new SelectList(db.Brands, "Id", "Name", product.BrandID);
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", product.CategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.BrandID = new SelectList(db.Brands, "Id", "Name", product.BrandID);
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", product.CategoryID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Quantity,Price,Image,CategoryID,BrandID")] Product product, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                string catImg = product.Image;
                try
                {
                    if (Image != null)
                    {
                        string fileName = Path.GetFileName(Image.FileName);// lay url path khi upload len
                        string path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                        Image.SaveAs(path);
                        catImg = "~/Uploads/" + fileName;
                    }

                }
                catch (Exception e)
                {
                }
                finally
                {
                    product.Image = catImg;// set giá trị sau khi upload ảnh lên vào product
                }
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandID = new SelectList(db.Brands, "Id", "Name", product.BrandID);
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", product.CategoryID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}