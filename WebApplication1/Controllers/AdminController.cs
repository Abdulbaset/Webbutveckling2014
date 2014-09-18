using System.Web.Mvc;
using WebApplication1.Persistence;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            var repo = new OrderRepository();
            var pendingOrders = repo.GetPendingOrders();
            return View(pendingOrders);
        }
    }
}