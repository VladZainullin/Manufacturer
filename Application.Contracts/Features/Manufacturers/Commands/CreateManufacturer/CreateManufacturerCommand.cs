using MediatR;

namespace Application.Contracts.Features.Manufacturers.Commands.CreateManufacturer;

public sealed record CreateManufacturerCommand(CreateManufacturerRequestBodyDto BodyDto) : 
    IRequest<CreateManufacturerResponseDto>;