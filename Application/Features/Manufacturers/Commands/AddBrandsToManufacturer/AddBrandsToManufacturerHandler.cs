using Application.Contracts.Features.Manufacturers.Commands.AddBrandsToManufacturer;
using Domain.Manufacturers;
using Domain.Manufacturers.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Manufacturers.Commands.AddBrandsToManufacturer;

public sealed class AddBrandsToManufacturerHandler(IDbContext context) :
    IRequestHandler<AddBrandsToManufacturerCommand>
{
    public async Task Handle(
        AddBrandsToManufacturerCommand request,
        CancellationToken cancellationToken)
    {
        var manufacturer = await GetManufacturerAsync(request.RouteDto.ManufacturerId, cancellationToken);
        if (ReferenceEquals(manufacturer, default)) return;

        manufacturer.AddBrands(new AddManufacturerBrandsParameters
        {
            Brands = request.BodyDto.Brands
                .Select(static b => new AddManufacturerBrandsParameters.BrandDto
                {
                    Title = b.Title,
                    Description = b.Description
                })
        });

        await context.SaveChangesAsync(cancellationToken);
    }

    private Task<Manufacturer?> GetManufacturerAsync(Guid manufacturerId, CancellationToken cancellationToken)
    {
        return context.Manufacturers
            .Where(m => m.Id == manufacturerId)
            .SingleOrDefaultAsync(cancellationToken);
    }
}