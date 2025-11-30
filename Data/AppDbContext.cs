using FruitManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FruitManagementAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Fruit> Fruits { get; set; }
    }
}
