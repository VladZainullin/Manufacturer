namespace Domain.Manufacturers.Parameters;

public readonly struct SetManufacturerTitleParameters
{
    public required string Title { get; init; }
    
    public required TimeProvider TimeProvider { get; init; }
}