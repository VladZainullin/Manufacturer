namespace Application.Contracts.Features.Manufacturers.Queries.GetManufacturers;

public sealed class GetManufacturersResponseDto
{
    public required IReadOnlyCollection<ManufacturerDto> Manufacturers { get; init; }
    
    public sealed class ManufacturerDto
    {
        public required Guid Id { get; init; }
        
        public required string Title { get; init; }
    }
}