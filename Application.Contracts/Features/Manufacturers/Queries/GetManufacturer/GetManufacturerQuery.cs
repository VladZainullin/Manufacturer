using MediatR;

namespace Application.Contracts.Features.Manufacturers.Queries.GetManufacturer;

public sealed record GetManufacturerQuery(GetManufacturerRequestRouteDto RouteDto) :
    IRequest<GetManufacturerResponseDto>;