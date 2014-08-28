using System.Collections.Generic;

namespace WebApplication1.Models
{
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
}