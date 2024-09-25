namespace Application.Contracts.Features.Manufacturers.Commands.CreateManufacturer;

public sealed class CreateManufacturerResponseDto
{
    public required Guid ManufacturerId { get; init; }
}