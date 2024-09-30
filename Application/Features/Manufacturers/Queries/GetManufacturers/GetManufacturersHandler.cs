using Application.Contracts.Features.Manufacturers.Queries.GetManufacturers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Manufacturers.Queries.GetManufacturers;

file sealed class GetManufacturersHandler(IDbContext context) :
    IRequestHandler<GetManufacturersQuery, GetManufacturersResponseDto>
{
    public async Task<GetManufacturersResponseDto> Handle(
        GetManufacturersQuery request,
        CancellationToken cancellationToken)
    {
        return new GetManufacturersResponseDto
        {
            Manufacturers = await context.Manufacturers
                .AsNoTracking()
                .Select(static m => new GetManufacturersResponseDto.ManufacturerDto
                {
                    Id = m.Id,
                    Title = m.Title
                })
                .Skip(request.QueryDto.Skip)
                .Take(request.QueryDto.Take)
                .ToListAsync(cancellationToken)
        };
    }
}