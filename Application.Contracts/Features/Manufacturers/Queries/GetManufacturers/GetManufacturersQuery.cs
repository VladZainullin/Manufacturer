using Application.Features.Manufacturers.Queries.GetManufacturers;
using MediatR;

namespace Application.Contracts.Features.Manufacturers.Queries.GetManufacturers;

public sealed record GetManufacturersQuery(GetManufacturersRequestQueryDto QueryDto) : 
    IRequest<GetManufacturersResponseDto>;

public sealed class GetManufacturersResponseDto
{
    public required IReadOnlyCollection<ManufacturerDto> Manufacturers { get; init; }
    
    public sealed class ManufacturerDto
    {
        public required Guid Id { get; init; }
        
        public required string Title { get; init; }
    }
}