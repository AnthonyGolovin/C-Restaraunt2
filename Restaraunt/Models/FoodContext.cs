using Microsoft.EntityFrameworkCore;

namespace Food.Models
{
  public class FoodContext : DbContext
  {
    public virtual DbSet<Cuisine> Cuisines { get; set; } 
    public DbSet<Restaurant> Restaurants { get; set; }

    public FoodContext(DbContextOptions options) : base(options) { }
  }
}