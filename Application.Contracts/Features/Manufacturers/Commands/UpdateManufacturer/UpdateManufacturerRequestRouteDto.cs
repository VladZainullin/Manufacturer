namespace Application.Contracts.Features.Manufacturers.Commands.UpdateManufacturer;

public sealed class UpdateManufacturerRequestRouteDto
{
    public required Guid ManufacturerId { get; init; }
}