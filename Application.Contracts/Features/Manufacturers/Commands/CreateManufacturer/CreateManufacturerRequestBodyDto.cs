namespace Application.Contracts.Features.Manufacturers.Commands.CreateManufacturer;

public sealed class CreateManufacturerRequestBodyDto
{
    public required string Title { get; init; }

    public required string Description { get; init; }
    
    public sealed class BrandDto
    {
        public required string Title { get; init; }
    }
}