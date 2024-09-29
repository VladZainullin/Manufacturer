namespace Application.Contracts.Features.Manufacturers.Commands.AddBrandsToManufacturer;

public sealed class AddBrandsToManufacturerRequestRouteDto
{
    public required Guid ManufacturerId { get; init; }
}