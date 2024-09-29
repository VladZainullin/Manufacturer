namespace Application.Contracts.Features.Manufacturers.Commands.DeleteBrandsFromManufacturer;

public sealed class DeleteBrandsToManufacturerRequestBodyDto
{
    public required IEnumerable<Guid> BrandIds { get; init; }
}