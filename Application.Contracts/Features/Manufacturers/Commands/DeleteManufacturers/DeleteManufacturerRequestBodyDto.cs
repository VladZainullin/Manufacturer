namespace Application.Contracts.Features.Manufacturers.Commands.DeleteManufacturers;

public sealed class DeleteManufacturerRequestBodyDto
{
    public required IReadOnlyCollection<Guid> Ids { get; init; }
}