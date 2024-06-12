using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class CarRentalDbContext : DbContext
{
    public CarRentalDbContext()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@$"Server=localhost;Database=CarRentalDB;User Id=sa;Password=Asdf.9999;TrustServerCertificate=True");
    }
    
    public DbSet<Car> Cars { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Color> Colors { get; set; }
    
}