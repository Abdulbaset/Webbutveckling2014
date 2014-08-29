using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Persistance;

namespace WebApplication1.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult Index()
        {
            var orderModel = new OrderViewModel();

            return View(orderModel);
        }

        [HttpPost]
        public ActionResult Index(OrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Dishes.Sum(x => x.OrderedQty) == 0)
            {
                model.QtyErrorMessage = "Fel antal!";
                return View(model);
            }

            var orderRepository = new OrderRepository();
            var order = new Order();
            order.Email = model.Email;
            foreach (var orderedDish in model.Dishes)
            {
                if (orderedDish.OrderedQty > 0)
                {
                    order.AddOrderDetail(orderedDish.Id, orderedDish.OrderedQty);
                }
            }

            var orderId = orderRepository.Save(order);

            return RedirectToAction("Confirm", new { Id = orderId });
        }

        public ActionResult Confirm(int? id)
        {
            var dishRepository = new DishRepository();
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
    }
}