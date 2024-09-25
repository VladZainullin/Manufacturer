namespace Application.Contracts.Features.Manufacturers.Commands.UpdateManufacturer;

public sealed class UpdateManufacturerRequestBodyDto
{
    public required string Title { get; init; }

    public required string Description { get; init; }
}