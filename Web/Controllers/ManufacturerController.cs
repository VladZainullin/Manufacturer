using Application.Contracts.Features.Manufacturers.Commands.DeleteManufacturer;
using Application.Contracts.Features.Manufacturers.Commands.UpdateManufacturer;
using Application.Contracts.Features.Manufacturers.Queries.GetManufacturer;
using Application.Contracts.Features.Manufacturers.Queries.GetManufacturers;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/manufacturers/{manufacturerId:guid}")]
public sealed class ManufacturerController : AppController
{
    [HttpPut]
    public async Task<NoContentResult> UpdateManufacturerAsync(
        [FromRoute] UpdateManufacturerRequestRouteDto routeDto,
        [FromBody] UpdateManufacturerRequestBodyDto bodyDto)
    {
        await Sender.Send(new UpdateManufacturerCommand(routeDto, bodyDto), HttpContext.RequestAborted);
        return NoContent();
    }

    [HttpDelete]
    public async Task<NoContentResult> DeleteManufacturerAsync(
        [FromRoute] DeleteManufacturerRequestRouteDto routeDto)
    {
        await Sender.Send(new DeleteManufacturerCommand(routeDto), HttpContext.RequestAborted);

        return NoContent();
    }
    
    [HttpGet]
    public async Task<ActionResult<GetManufacturersResponseDto>> GetManufacturerAsync(
        [FromRoute] GetManufacturerRequestRouteDto routeDto)
    {
        return Ok(await Sender.Send(new GetManufacturerQuery(routeDto), HttpContext.RequestAborted));
    }
}