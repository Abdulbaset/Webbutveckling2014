using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.Persistence
{
    public class LunchDbContext : DbContext
    {
        public LunchDbContext() : base("LunchDatabas") {}

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}