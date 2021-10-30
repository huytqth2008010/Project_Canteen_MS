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
using System.Data.Entity.Migrations;

namespace Project_Canteen_MS.Areas.Admin.Controllers
{
    public class SlidesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/Slides
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Slides.ToList());
        }

        // GET: Admin/Slides/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide slide = db.Slides.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // GET: Admin/Slides/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Slides/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Content,Image")] Slide slide, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                string catImg = "~/Uploads/default.png"; //edit -  category.Image
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
                    slide.Image = catImg;// set giá trị sau khi upload ảnh lên vào category
                }
                db.Slides.Add(slide);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slide);
        }

        // GET: Admin/Slides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide slide = db.Slides.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // POST: Admin/Slides/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,Image")] Slide slide, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {

                string catImg = slide.Image; //edit -  category.Image
                try
                {
                    if (Image != null)
                    {
                        string fileName = Path.GetFileName(Image.FileName);// lay url path khi upload len
                        string path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                        Image.SaveAs(path);
                        catImg = "~/Uploads/" + fileName;
                    }
                    else
                    {
                        return RedirectToAction("Index");
                      }
                }
                catch (Exception e)
                {
                }
                finally
                {
                    slide.Image = catImg;// set giá trị sau khi upload ảnh lên vào category
                }
                db.Entry(slide).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slide);
        }

        // GET: Admin/Slides/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Slide slide = db.Slides.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            db.Slides.Remove(slide);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
