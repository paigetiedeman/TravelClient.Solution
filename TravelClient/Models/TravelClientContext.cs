using Microsoft.EntityFrameworkCore;

namespace TravelClient.Models
{
  public class TravelClientContext : DbContext
  {
    public TravelClientContext(DbContextOptions<TravelClientContext>  options) : base(options) {}

    public DbSet<Review> Reviews { get; set; }
  }
}