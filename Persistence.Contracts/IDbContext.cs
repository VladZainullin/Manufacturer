using Domain.Brands;
using Domain.Manufacturers;

namespace Persistence.Contracts;

public interface IDbContext
{
    IDbSet<Manufacturer> Manufacturers { get; }
    
    IDbSet<Brand> Brands { get; }
    
    Task SaveChangesAsync(CancellationToken cancellationToken);
}