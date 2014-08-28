using System.Collections.Generic;
using System.Linq;
using WebApplication1.Controllers;

namespace WebApplication1.Models
{
    public class ConfirmOrderModel
    {
        public ConfirmOrderModel()
        {
            OrderedDishes = new List<OrderedDish>();
        }

        public List<OrderedDish> OrderedDishes { get; set; }
        public string Email { get; set; }

        public void AddDish(Dish dish, int quantity)
        {
            var orderedDish = new OrderedDish();
            orderedDish.Name = dish.Name;
            orderedDish.Price = dish.Price;
            orderedDish.Quantity = quantity;

            OrderedDishes.Add(orderedDish);
        }

        public decimal TotalAmount
        {
            get { return OrderedDishes.Sum(d => d.Quantity * d.Price); }
        }
    }
}