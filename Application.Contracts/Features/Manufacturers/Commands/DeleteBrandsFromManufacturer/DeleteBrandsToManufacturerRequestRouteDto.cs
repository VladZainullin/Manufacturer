namespace Application.Contracts.Features.Manufacturers.Commands.DeleteBrandsFromManufacturer;

public sealed class DeleteBrandsToManufacturerRequestRouteDto
{
    public required Guid ManufacturerId { get; init; }
}