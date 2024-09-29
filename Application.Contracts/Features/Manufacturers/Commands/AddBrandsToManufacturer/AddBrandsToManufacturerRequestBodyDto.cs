namespace Application.Contracts.Features.Manufacturers.Commands.AddBrandsToManufacturer;

public sealed class AddBrandsToManufacturerRequestBodyDto
{
    public required IReadOnlyCollection<BrandDto> Brands { get; init; }
    
    public sealed class BrandDto
    {
        public required string Title { get; init; }

        public required string Description { get; init; }
    }
}