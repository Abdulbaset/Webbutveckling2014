using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Order
    {
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public void AddOrderDetail(int id, int quantity)
        {
            var orderDetail = new OrderDetail();
            orderDetail.DishId = id;
            orderDetail.Quantity = quantity;
            OrderDetails.Add(orderDetail);
        }
    }

    public class OrderDetail
    {
        public int DishId { get; set; }
        public int Quantity { get; set; }
    }
}