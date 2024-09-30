namespace Application.Contracts.Features.Manufacturers.Queries.GetManufacturers;

public sealed class GetManufacturersRequestQueryDto
{
    public required int Skip { get; init; }

    public required int Take { get; init; }
}