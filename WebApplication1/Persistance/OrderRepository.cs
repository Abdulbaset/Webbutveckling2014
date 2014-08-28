using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Persistance
{
    public class OrderRepository
    {
        private static readonly List<Order> _orders = new List<Order>();

        public int Save(Order order)
        {
            var newId = _orders
                .Select(o => o.Id)
                .DefaultIfEmpty().Max() + 1;
            order.Id = newId;

            _orders.Add(order);
            return newId;
        }

        public Order GetById(int id)
        {
            return _orders.FirstOrDefault(o => o.Id == id);
        }
    }
}