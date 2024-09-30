using Application.Contracts.Features.Manufacturers.Commands.UpdateManufacturer;
using MediatR;

namespace Application.Contracts.Features.Manufacturers.Commands.UpdateBrand;

public sealed record UpdateBrandCommand(
    UpdateBrandRequestRouteDto RouteDto,
    UpdateManufacturerRequestBodyDto BodyDto) : IRequest;