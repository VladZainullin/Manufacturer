using Application.Contracts.Features.Manufacturers.Commands.DeleteBrandsFromManufacturer;
using Domain.Brands;
using Domain.Manufacturers;
using Domain.Manufacturers.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Manufacturers.Commands.DeleteBrandsFromManufacturer;

public sealed class DeleteBrandsToManufacturerHandler(IDbContext context, TimeProvider timeProvider) : 
    IRequestHandler<DeleteBrandsToManufacturerCommand>
{
    public async Task Handle(DeleteBrandsToManufacturerCommand request, CancellationToken cancellationToken)
    {
        var manufacturer = await GetManufacturerAsync(request.RouteDto.ManufacturerId, cancellationToken);
        if (ReferenceEquals(manufacturer, default)) return;
        
        manufacturer.RemoveBrands(new RemoveManufacturerBrandsParameters
        {
            Brands = await GetBrandsAsync(request.BodyDto.BrandIds,
                cancellationToken),
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }

    private Task<Manufacturer?> GetManufacturerAsync(Guid manufacturerId, CancellationToken cancellationToken)
    {
        return context.Manufacturers
            .Include(static m => m.Brands)
            .AsTracking()
            .Where(m => m.Id == manufacturerId)
            .SingleOrDefaultAsync(cancellationToken);
    }

    private Task<List<Brand>> GetBrandsAsync(IEnumerable<Guid> brandIds, CancellationToken cancellationToken)
    {
        return context.Brands
            .AsTracking()
            .Where(b => brandIds.Contains(b.Id))
            .ToListAsync(cancellationToken);
    }
}