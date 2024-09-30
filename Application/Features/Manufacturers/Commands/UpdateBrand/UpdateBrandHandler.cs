using Application.Contracts.Features.Manufacturers.Commands.UpdateBrand;
using Domain.Brands.Parameters;
using Domain.Manufacturers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Manufacturers.Commands.UpdateBrand;

file sealed class UpdateBrandHandler(IDbContext context) : IRequestHandler<UpdateBrandCommand>
{
    public async Task Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        var manufacturer = await GetManufacturerAsync(
            request.RouteDto.ManufacturerId,
            cancellationToken);

        if (ReferenceEquals(manufacturer, default)) return;

        var brand = manufacturer.Brands.SingleOrDefault(b => b.Id == request.RouteDto.BrandId);
        
        if (ReferenceEquals(brand, default)) return;
        
        brand.SetTitle(new SetBrandTitleParameters
        {
            Title = request.BodyDto.Title
        });
        
        brand.SetDescription(new SetBrandDescriptionParameters
        {
            Description = request.BodyDto.Description
        });

        await context.SaveChangesAsync(cancellationToken);
    }

    private Task<Manufacturer?> GetManufacturerAsync(Guid manufacturerId, CancellationToken cancellationToken)
    {
        return context.Manufacturers
            .AsTracking()
            .Where(m => m.Id == manufacturerId)
            .SingleOrDefaultAsync(cancellationToken);
    }
}