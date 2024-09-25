namespace Application.Contracts.Features.Manufacturers.Commands.CreateManufacturer;

public sealed class CreateManufacturerRequestBodyDto
{
    public required string Title { get; init; }

    public required string Description { get; init; }
}