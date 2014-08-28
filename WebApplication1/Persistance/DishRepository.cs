using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Persistance
{
    public class DishRepository
    {
         private readonly List<Dish> _dishes = new List<Dish>
             {
                 new Dish { Id = 1, Name = "Dagens pizza", Price = 55.0m},
                 new Dish { Id = 2, Name = "Dagens pasta", Price = 49.0m},
                 new Dish { Id = 3, Name = "Sallad", Price = 50.0m},
                 new Dish { Id = 4, Name = "Kebabtallrik", Price = 59.0m},
             };

        public List<Dish> GetAll()
        {
            return _dishes;
        }

        public Dish GetById(int id)
        {
            return _dishes.FirstOrDefault(d => d.Id == id);
        }
    }
}