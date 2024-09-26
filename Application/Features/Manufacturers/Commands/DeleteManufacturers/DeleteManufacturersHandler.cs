using Application.Contracts.Features.Manufacturers.Commands.DeleteManufacturers;
using Domain.Manufacturers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Manufacturers.Commands.DeleteManufacturers;

public sealed class DeleteManufacturersHandler(IDbContext context) : IRequestHandler<DeleteManufacturersCommand>
{
    public async Task Handle(DeleteManufacturersCommand request, CancellationToken cancellationToken)
    {
        var manufacturers = await GetManufacturersAsync(request.BodyDto.Ids, cancellationToken);
        
        context.Manufacturers.RemoveRange(manufacturers);
        await context.SaveChangesAsync(cancellationToken);
    }

    private Task<List<Manufacturer>> GetManufacturersAsync(
        IEnumerable<Guid> manufacturerIds,
        CancellationToken cancellationToken)
    {
        return context.Manufacturers
            .Where(m => manufacturerIds.Contains(m.Id))
            .ToListAsync(cancellationToken);
    }
}