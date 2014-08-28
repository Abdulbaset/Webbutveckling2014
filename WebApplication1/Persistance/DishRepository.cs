using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Persistance
{
    public class DishRepository
    {
         private readonly DishList _dishes = new DishList
             {
                 { 1, "Dagens pizza", 55.0m},
                 { 2, "Dagens pasta", 49.0m},
                 { 3, "Sallad", 50.0m},
                 { 4, "Kebabtallrik", 59.0m},
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

    public class DishList : List<Dish>
    {
        public void Add(int id, string name, decimal price)
        {
            Add(new Dish { Id = id, Name = name, Price = price });
        }
    }
}