using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace WebApplication1.Models
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Email { get; set; }
        public bool IsServed { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

        public void AddOrderDetail(int id, int quantity)
        {
            var orderDetail = new OrderDetail();
            orderDetail.DishId = id;
            orderDetail.Quantity = quantity;
            OrderDetails.Add(orderDetail);
        }

        public decimal TotalAmount
        {
            get
            {
                return OrderDetails
                    .Sum(d => d.Quantity * d.Dish.Price);
            }
        }
    }
}