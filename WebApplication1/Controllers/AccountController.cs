using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var role = model.EmployeeNumber % 2 == 0 ? "admin" : "user";

            Session["role"] = role;

            return RedirectToAction("Index", "Order");
        }

        public ActionResult Logout()
        {
            Session.Remove("role");
            return RedirectToAction("Index", "Order");
        }
    }

    public class LoginModel
    {
        [DisplayName("Anst.nr")]
        public int EmployeeNumber { get; set; }
        [DisplayName("Lösenord")]
        public string Password { get; set; }
    }
}