using MediatR;

namespace Application.Contracts.Features.Manufacturers.Commands.DeleteManufacturer;

public sealed record DeleteManufacturerCommand(DeleteManufacturerRequestRouteDto RouteDto) : IRequest;