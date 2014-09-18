using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.Persistence
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
                var firstOrDefault = context.Orders
                    .Include(o => o.OrderDetails)
                    .Include(o => o.OrderDetails.Select(d => d.Dish))
                    .FirstOrDefault(o => o.Id == id);
                return firstOrDefault;
            }
        }

        public List<Order> GetPendingOrders()
        {
            using (var context = new LunchDbContext())
            {
                return context.Orders
                    .Include(o => o.OrderDetails)
                    .Include(o => o.OrderDetails.Select(d => d.Dish))
                    .Where(o => !o.IsServed)
                    .ToList();
            }
        }
    }
}