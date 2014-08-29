using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Persistance
{
    public class DishRepository
    {
        public List<Dish> GetAll()
        {
            using (var context = new LunchDbContext())
            {
                return context.Dishes.ToList();
            }
        }

        public Dish GetById(int id)
        {
            using (var context = new LunchDbContext())
            {
                return context.Dishes.FirstOrDefault(d => d.Id == id);
            }
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