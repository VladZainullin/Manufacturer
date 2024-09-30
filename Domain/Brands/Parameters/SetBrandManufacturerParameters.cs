using Domain.Manufacturers;

namespace Domain.Brands.Parameters;

public readonly struct SetBrandManufacturerParameters
{
    public required Manufacturer Manufacturer { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}