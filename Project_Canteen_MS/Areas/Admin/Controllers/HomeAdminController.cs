using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project_Canteen_MS.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        // phai dang nhap vao thi moi xem dc
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            //WebSecurity.Logout();
            FormsAuthentication.SignOut();
            return RedirectToAction("~/Admin/AuthAdmin/Login");
        }
    }
}