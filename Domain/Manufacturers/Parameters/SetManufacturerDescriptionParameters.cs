namespace Domain.Manufacturers.Parameters;

public readonly struct SetManufacturerDescriptionParameters
{
    public required string Description { get; init; }
    
    public required TimeProvider TimeProvider { get; init; }
}