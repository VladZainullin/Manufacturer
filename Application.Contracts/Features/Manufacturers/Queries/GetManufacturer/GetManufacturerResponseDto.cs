namespace Application.Contracts.Features.Manufacturers.Queries.GetManufacturer;

public sealed class GetManufacturerResponseDto
{
    public required string Title { get; init; }

    public required string Description { get; init; }
}