using Application.Contracts.Features.Manufacturers.Queries.GetManufacturer;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Manufacturers.Queries.GetManufacturer;

file sealed class GetManufacturerHandler(IDbContext context) : 
    IRequestHandler<GetManufacturerQuery, GetManufacturerResponseDto>
{
    public Task<GetManufacturerResponseDto> Handle(
        GetManufacturerQuery request,
        CancellationToken cancellationToken)
    {
        return context.Manufacturers
            .AsNoTracking()
            .Where(m => m.Id == request.RouteDto.Id)
            .Select(static m => new GetManufacturerResponseDto
            {
                Title = m.Title,
                Description = m.Description
            })
            .SingleAsync(cancellationToken);
    }
}