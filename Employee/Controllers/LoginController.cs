using Employee.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class LoginController : Controller
    {
        Contxt db = new Contxt();
       // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Mail()
        {
            return View();
        }
        public ActionResult LoginUser(string Email, string Pass)
        {
            var users = db.User.Where(b => b.Email == Email && b.Password == Pass && b.Status == true).FirstOrDefault();
            if (users != null)
            {
                MyCookies.SaveUser(users);
                return RedirectToAction("Employee", "Home");
            }
            TempData["Uid"] = Email;
            TempData["Pwd"] = Pass;
            TempData["Msg"] = "Please enter correct credentials!";
            return RedirectToAction("Login");

        }
        public ActionResult Logout()
        {
            MyCookies.Logout();
            return RedirectToAction("Login");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}