using Domain.Manufacturers;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence;

public sealed class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Manufacturer> Manufacturers => Set<Manufacturer>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ManufacturerConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}