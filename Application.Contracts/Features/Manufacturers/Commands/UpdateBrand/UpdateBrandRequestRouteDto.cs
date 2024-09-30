namespace Application.Contracts.Features.Manufacturers.Commands.UpdateBrand;

public sealed class UpdateBrandRequestRouteDto
{
    public required Guid ManufacturerId { get; init; }

    public required Guid BrandId { get; init; }
}