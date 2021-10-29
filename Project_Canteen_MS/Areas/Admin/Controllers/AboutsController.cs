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
    public class AboutsController : Controller
    {
        private DataContext context = new DataContext();

        // GET: Categories
        [Authorize]
        public ActionResult Index()
        {
            return View(context.Abouts.ToList());
        }

        [Authorize] // phai dang nhap vao thi moi xem dc
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            About about = context.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Content ")] About about)
        {
            if (ModelState.IsValid)
            {
                // upload image
               
                context.Abouts.Add(about);// them 1 object vao list
                context.SaveChanges();// luu vao db
                return RedirectToAction("Index");
            }
            return View(about);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            About about = context.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title, Content")] About about)
        {
            if (ModelState.IsValid)
            {
                context.Entry(about).State = System.Data.Entity.EntityState.Modified; // bao rang day la trang thai chinh sua
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(about);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            About about = context.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            context.Abouts.Remove(about);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}