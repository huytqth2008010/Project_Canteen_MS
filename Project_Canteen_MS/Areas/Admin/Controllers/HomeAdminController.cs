using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}