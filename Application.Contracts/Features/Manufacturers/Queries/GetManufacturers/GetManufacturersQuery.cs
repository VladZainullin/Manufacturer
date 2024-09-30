using MediatR;

namespace Application.Contracts.Features.Manufacturers.Queries.GetManufacturers;

public sealed record GetManufacturersQuery(GetManufacturersRequestQueryDto QueryDto) : 
    IRequest<GetManufacturersResponseDto>;