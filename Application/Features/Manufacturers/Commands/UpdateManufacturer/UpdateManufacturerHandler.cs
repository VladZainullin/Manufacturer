using Application.Contracts.Features.Manufacturers.Commands.UpdateManufacturer;
using Domain.Manufacturers;
using Domain.Manufacturers.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Manufacturers.Commands.UpdateManufacturer;

file sealed class UpdateManufacturerHandler(IDbContext context, TimeProvider timeProvider) : IRequestHandler<UpdateManufacturerCommand>
{
    public async Task Handle(UpdateManufacturerCommand request, CancellationToken cancellationToken)
    {
        var manufacturer = await GetManufacturerAsync(request.RouteDto.ManufacturerId, cancellationToken);
        if (ReferenceEquals(manufacturer, default)) return;

        var setTitleParameters = new SetManufacturerTitleParameters
        {
            Title = request.BodyDto.Title,
            TimeProvider = timeProvider
        };
        manufacturer.SetTitle(setTitleParameters);

        var setDescriptionParameters = new SetManufacturerDescriptionParameters
        {
            Description = request.BodyDto.Description,
            TimeProvider = timeProvider
        };
        manufacturer.SetDescription(setDescriptionParameters);

        await context.SaveChangesAsync(cancellationToken);
    }

    private Task<Manufacturer?> GetManufacturerAsync(Guid manufacturerId, CancellationToken cancellationToken)
    {
        return context.Manufacturers
            .AsTracking()
            .SingleOrDefaultAsync(m => m.Id == manufacturerId, cancellationToken);
    }
}