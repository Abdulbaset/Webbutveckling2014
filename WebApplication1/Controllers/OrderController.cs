using System.Collections.Generic;
using System.Threading;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Persistance;

namespace WebApplication1.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Confirm(int? id)
        {
            var orderRepository = new OrderRepository();

            if (id == null)
            {
                return View();
            }

            var order = orderRepository.GetById(id.Value);

            if (order == null)
            {
                return View();
            }

            return View(order);
        }

        public ActionResult GetDishes()
        {
            Thread.Sleep(500);
            var orderViewModel = new OrderViewModel();
            List<DishViewModel> dishes = orderViewModel.Dishes;
            return Json(dishes, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Submit(SubmitOrderModel model)
        {
            var orderRepository = new OrderRepository();
            var order = new Order();
            order.Email = model.Email;
            foreach (var orderedDish in model.Dishes)
            {
                if (orderedDish.Quantity > 0)
                {
                    order.AddOrderDetail(orderedDish.Id, orderedDish.Quantity);
                }
            }

            var orderId = orderRepository.Save(order);

            return Json(new { orderId, confirmLink = Url.Action("Confirm", new { id = orderId }) });
        }
    }
}