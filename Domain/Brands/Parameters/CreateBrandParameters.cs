namespace Domain.Brands.Parameters;

public readonly struct CreateBrandParameters
{
    public required string Title { get; init; }

    public required string Description { get; init; }
}