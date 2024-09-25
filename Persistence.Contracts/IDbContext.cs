using Domain.Manufacturers;

namespace Persistence.Contracts;

public interface IDbContext
{
    IDbSet<Manufacturer> Manufacturers { get; }
    
    Task SaveChangesAsync(CancellationToken cancellationToken);
}