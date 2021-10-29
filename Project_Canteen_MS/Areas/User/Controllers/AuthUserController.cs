using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Canteen_MS.Models;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
namespace Project_Canteen_MS.Areas.User.Controllers
{
    public class AuthUserController : Controller
    {
        // GET: User/AuthUser
        private DataContext db = new DataContext();
        // GET: Autheticate
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Models.User user)
        {
            if (ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s => s.Email == user.Email);// lay user co email nhap vao
                if (check == null)
                {
                    // tao password - SHA256
                    user.Password = GetMD5(user.Password);
                    db.Users.Add(user);
                    db.SaveChanges();
                    FormsAuthentication.SetAuthCookie(user.Email, true);
                    return Redirect("~/Admin/HomeAdmin");
                }
                else
                {
                    ViewBag.Error = "Email này đã tồn tại";
                }
            }
            return View();
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] frData = Encoding.UTF8.GetBytes(str);
            byte[] toData = md5.ComputeHash(frData);
            string hashString = "";
            for (int i = 0; i < toData.Length; i++)
            {
                hashString += toData[i].ToString("x2");
            }
            return hashString;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                login.Password = GetMD5(login.Password);
                var data = db.Users.Where(s => s.Email.Equals(login.Email) && s.Password.Equals(login.Password)).FirstOrDefault();
                if (data != null)
                {
                    FormsAuthentication.SetAuthCookie(data.Email, true);
                    return Redirect("~/Admin/HomeAdmin");
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult LogOff()
        {
            //WebSecurity.Logout();
            FormsAuthentication.SignOut();
            return Redirect("#");
        }
    }
}