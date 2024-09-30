using MediatR;

namespace Application.Contracts.Features.Manufacturers.Commands.UpdateBrand;

public sealed record UpdateBrandCommand(
    UpdateBrandRequestRouteDto RouteDto,
    UpdateBrandRequestBodyDto BodyDto) : IRequest;