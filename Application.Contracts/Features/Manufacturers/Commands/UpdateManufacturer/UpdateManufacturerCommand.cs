using MediatR;

namespace Application.Contracts.Features.Manufacturers.Commands.UpdateManufacturer;

public sealed record UpdateManufacturerCommand(
    UpdateManufacturerRequestRouteDto RouteDto,
    UpdateManufacturerRequestBodyDto BodyDto) : IRequest;