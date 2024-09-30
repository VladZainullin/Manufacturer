using Application.Contracts.Features.Manufacturers.Commands.CreateManufacturer;
using Domain.Manufacturers;
using Domain.Manufacturers.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Manufacturers.Commands.CreateManufacturer;

file sealed class CreateManufacturerHandler(IDbContext context, TimeProvider timeProvider) : 
    IRequestHandler<CreateManufacturerCommand, CreateManufacturerResponseDto>
{
    public async Task<CreateManufacturerResponseDto> Handle(
        CreateManufacturerCommand request,
        CancellationToken cancellationToken)
    {
        var oldManufacturer = await GetManufacturerAsync(request.BodyDto.Title, cancellationToken);
        if (!ReferenceEquals(oldManufacturer, default))
            return new CreateManufacturerResponseDto
            {
                ManufacturerId = oldManufacturer.Id
            };
        
        var parameters = new CreateManufacturerParameters
        {
            Title = request.BodyDto.Title,
            Description = request.BodyDto.Description,
            TimeProvider = timeProvider
        };
        var manufacturer = new Manufacturer(parameters);
            
        context.Manufacturers.Add(manufacturer);
        await context.SaveChangesAsync(cancellationToken);
            
        return new CreateManufacturerResponseDto
        {
            ManufacturerId = manufacturer.Id
        };

    }

    private Task<Manufacturer?> GetManufacturerAsync(string manufacturerTitle, CancellationToken cancellationToken)
    {
        return context.Manufacturers
            .AsTracking()
            .SingleOrDefaultAsync(m => m.Title == manufacturerTitle, cancellationToken);
    }
}