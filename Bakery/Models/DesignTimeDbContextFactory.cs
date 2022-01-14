using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Bakery.Models
{
  public class skylar_brockbankContextFactory : IDesignTimeDbContextFactory<skylar_brockbankContext>
  {

    skylar_brockbankContext IDesignTimeDbContextFactory<skylar_brockbankContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<skylar_brockbankContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new skylar_brockbankContext(builder.Options);
    }
  }
}