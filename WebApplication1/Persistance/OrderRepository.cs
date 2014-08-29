using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Persistance
{
    public class OrderRepository
    {
        public int Save(Order order)
        {
            using (var context = new LunchDbContext())
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }

            return order.Id;
        }

        public Order GetById(int id)
        {
            using (var context = new LunchDbContext())
            {
                return context.Orders
                    .Include("OrderDetails")
                    .FirstOrDefault(o => o.Id == id);
            }
        }

        public List<Order> GetPendingOrders()
        {
            using (var context = new LunchDbContext())
            {
                return context.Orders
                    .Include("OrderDetails")
                    .Where(o => !o.IsServed)
                    .ToList();
            }
        }
    }
}