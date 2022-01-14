using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Models
{
  public class skylar_brockbankContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<ApplicationUser> BakeryUsers {get;set;}
    public DbSet<Flavor> Flavors {get;set;}
    public DbSet<Treat> Treats {get;set;}
    public DbSet<FlavorTreat> Joins {get;set;}

    public skylar_brockbankContext(DbContextOptions options) : base(options){}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}