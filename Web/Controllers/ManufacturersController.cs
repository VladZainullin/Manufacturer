using Application.Contracts.Features.Manufacturers.Commands.CreateManufacturer;
using Application.Contracts.Features.Manufacturers.Commands.DeleteManufacturers;
using Application.Contracts.Features.Manufacturers.Queries.GetManufacturers;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("manufacturers")]
public sealed class ManufacturersController : AppController
{
    [HttpGet]
    public async Task<ActionResult<GetManufacturersResponseDto>> GetManufacturersAsync(
        [FromQuery] GetManufacturersRequestQueryDto queryDto)
    {
        return Ok(await Sender.Send(new GetManufacturersQuery(queryDto), HttpContext.RequestAborted));
    }
    
    [HttpPost]
    public async Task<ActionResult<CreateManufacturerResponseDto>> CreateManufacturerAsync(
        CreateManufacturerRequestBodyDto bodyDto)
    {
        var response = await Sender.Send(new CreateManufacturerCommand(bodyDto), HttpContext.RequestAborted);

        return Ok(response);
    }
    
    [HttpDelete]
    public async Task<NoContentResult> DeleteManufacturersAsync(
        [FromRoute] DeleteManufacturersRequestBodyDto bodyDto)
    {
        await Sender.Send(new DeleteManufacturersCommand(bodyDto), HttpContext.RequestAborted);

        return NoContent();
    }
}