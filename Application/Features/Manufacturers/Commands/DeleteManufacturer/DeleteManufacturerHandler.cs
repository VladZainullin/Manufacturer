using Application.Contracts.Features.Manufacturers.Commands.DeleteManufacturer;
using Domain.Manufacturers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Manufacturers.Commands.DeleteManufacturer;

file sealed class DeleteManufacturerHandler(IDbContext context) : 
    IRequestHandler<DeleteManufacturerCommand>
{
    public async Task Handle(DeleteManufacturerCommand request, CancellationToken cancellationToken)
    {
        var manufacturer = await GetManufacturerAsync(request.RouteDto.Id, cancellationToken);

        if (ReferenceEquals(manufacturer, default)) return;

        context.Manufacturers.Remove(manufacturer);
        await context.SaveChangesAsync(cancellationToken);
    }

    private Task<Manufacturer?> GetManufacturerAsync(Guid manufacturerId, CancellationToken cancellationToken)
    {
        return context.Manufacturers
            .Where(m => m.Id == manufacturerId)
            .SingleOrDefaultAsync(cancellationToken);
    }
}