using Domain.Brands;
using Domain.Manufacturers;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence;

internal sealed class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Manufacturer> Manufacturers => Set<Manufacturer>();

    public DbSet<Brand> Brands => Set<Brand>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ManufacturerConfiguration());
        modelBuilder.ApplyConfiguration(new BrandConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}