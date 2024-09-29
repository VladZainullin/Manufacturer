using MediatR;

namespace Application.Contracts.Features.Manufacturers.Commands.AddBrandsToManufacturer;

public sealed record AddBrandsToManufacturerCommand(
    AddBrandsToManufacturerRequestRouteDto RouteDto,
    AddBrandsToManufacturerRequestBodyDto BodyDto) : IRequest;