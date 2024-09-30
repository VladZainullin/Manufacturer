namespace Domain.Manufacturers.Parameters;

public readonly struct CreateManufacturerParameters
{
    public required string Title { get; init; }

    public required string Description { get; init; }
    
    public required TimeProvider TimeProvider { get; init; }
}