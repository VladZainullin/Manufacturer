using Domain.Brands;

namespace Domain.Manufacturers.Parameters;

public readonly struct RemoveManufacturerBrandsParameters
{
    public required IEnumerable<Brand> Brands { get; init; }
    
    public required TimeProvider TimeProvider { get; init; }
}