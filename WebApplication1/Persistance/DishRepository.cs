using System;
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

        public void CreateDish(Dish dish)
        {
            using (var context = new LunchDbContext())
            {
                context.Dishes.Add(dish);
                context.SaveChanges();
            }
        }

        public void UpdateDish(Dish dish)
        {
            using (var context = new LunchDbContext())
            {
                var original = context.Dishes.Find(dish.Id);
                if (original == null)
                {
                    throw new InvalidOperationException();
                }
                context.Entry(original).CurrentValues.SetValues(dish);
                context.SaveChanges();
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