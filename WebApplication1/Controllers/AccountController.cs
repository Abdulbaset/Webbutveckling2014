using System.Web.Mvc;
using WebApplication1.Models;

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
}