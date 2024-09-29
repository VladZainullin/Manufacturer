using MediatR;

namespace Application.Contracts.Features.Manufacturers.Commands.DeleteBrandsFromManufacturer;

public sealed record DeleteBrandsToManufacturerCommand(
    DeleteBrandsToManufacturerRequestRouteDto RouteDto,
    DeleteBrandsToManufacturerRequestBodyDto BodyDto) : IRequest;