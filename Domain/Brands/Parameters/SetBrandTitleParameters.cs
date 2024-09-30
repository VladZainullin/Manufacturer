namespace Domain.Brands.Parameters;

public readonly struct SetBrandTitleParameters
{
    public required string Title { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}