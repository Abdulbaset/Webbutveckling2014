using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.Persistance
{
    public class LunchDbContext : DbContext
    {
         public DbSet<Dish> Dishes { get; set; }
    }
}