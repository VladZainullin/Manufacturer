namespace Application.Contracts.Features.Manufacturers.Commands.DeleteManufacturer;

public sealed class DeleteManufacturerRequestRouteDto
{
    public required Guid Id { get; init; }
}