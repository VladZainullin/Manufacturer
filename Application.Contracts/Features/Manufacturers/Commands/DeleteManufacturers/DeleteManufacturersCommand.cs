using MediatR;

namespace Application.Contracts.Features.Manufacturers.Commands.DeleteManufacturers;

public sealed record DeleteManufacturersCommand(DeleteManufacturersRequestBodyDto BodyDto) : IRequest;