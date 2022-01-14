using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Models
{
  public class skylar_brockbankContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<ApplicationUser> BakeryUsers {get;set;}

    public skylar_brockbankContext(DbContextOptions options) : base(options){}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}