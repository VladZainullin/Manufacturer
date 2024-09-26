namespace Application.Contracts.Features.Manufacturers.Commands.DeleteManufacturers;

public sealed class DeleteManufacturersRequestBodyDto
{
    public required IReadOnlyCollection<Guid> Ids { get; init; }
}