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

            return RedirectToAction("ConfirmOrder", new { Id = orderId });
        }

        public ActionResult ConfirmOrder(int id)
        {
            var dishRepository = new DishRepository();
            var orderRepository = new OrderRepository();

            var order = orderRepository.GetById(id);

            var confirmModel = new ConfirmOrderModel();
            confirmModel.Email = order.Email;

            foreach (var detail in order.OrderDetails)
            {
                var dish = dishRepository.GetById(detail.DishId);
                confirmModel.AddDish(dish, detail.Quantity);
            }

            return View(confirmModel);
        }
    }
}