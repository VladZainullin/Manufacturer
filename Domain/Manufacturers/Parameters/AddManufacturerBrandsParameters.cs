namespace Domain.Manufacturers.Parameters;

public sealed class AddManufacturerBrandsParameters
{
    public required IEnumerable<BrandDto> Brands { get; init; }

    public required TimeProvider TimeProvider { get; init; }
    
    public sealed class BrandDto
    {
        public required string Title { get; init; }

        public required string Description { get; init; }
    }
}