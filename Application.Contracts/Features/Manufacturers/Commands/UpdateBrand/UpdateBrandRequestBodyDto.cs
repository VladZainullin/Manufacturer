namespace Application.Contracts.Features.Manufacturers.Commands.UpdateBrand;

public sealed class UpdateBrandRequestBodyDto
{
    public required string Title { get; init; }

    public required string Description { get; init; }
}