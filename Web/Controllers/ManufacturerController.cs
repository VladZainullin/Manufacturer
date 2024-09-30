using Application.Contracts.Features.Manufacturers.Commands.AddBrandsToManufacturer;
using Application.Contracts.Features.Manufacturers.Commands.CreateManufacturer;
using Application.Contracts.Features.Manufacturers.Commands.DeleteBrandsFromManufacturer;
using Application.Contracts.Features.Manufacturers.Commands.DeleteManufacturer;
using Application.Contracts.Features.Manufacturers.Commands.DeleteManufacturers;
using Application.Contracts.Features.Manufacturers.Commands.UpdateManufacturer;
using Application.Contracts.Features.Manufacturers.Queries.GetManufacturer;
using Application.Contracts.Features.Manufacturers.Queries.GetManufacturers;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/manufacturers")]
public sealed class ManufacturerController : AppController
{
    [HttpPost]
    public async Task<ActionResult<CreateManufacturerResponseDto>> CreateManufacturerAsync(
        CreateManufacturerRequestBodyDto bodyDto)
    {
        var response = await Sender.Send(new CreateManufacturerCommand(bodyDto), HttpContext.RequestAborted);

        return Ok(response);
    }

    [HttpPut("{manufacturerId:guid}")]
    public async Task<NoContentResult> UpdateManufacturerAsync(
        [FromRoute] UpdateManufacturerRequestRouteDto routeDto,
        [FromBody] UpdateManufacturerRequestBodyDto bodyDto)
    {
        await Sender.Send(new UpdateManufacturerCommand(routeDto, bodyDto), HttpContext.RequestAborted);
        return NoContent();
    }

    [HttpDelete("{manufacturerId:guid}")]
    public async Task<NoContentResult> DeleteManufacturerAsync(
        [FromRoute] DeleteManufacturerRequestRouteDto routeDto)
    {
        await Sender.Send(new DeleteManufacturerCommand(routeDto), HttpContext.RequestAborted);

        return NoContent();
    }
    
    [HttpDelete]
    public async Task<NoContentResult> DeleteManufacturersAsync(
        [FromRoute] DeleteManufacturersRequestBodyDto bodyDto)
    {
        await Sender.Send(new DeleteManufacturersCommand(bodyDto), HttpContext.RequestAborted);

        return NoContent();
    }

    [HttpPost("{manufacturerId:guid}/brands")]
    public async Task<NoContentResult> AddBrandsToManufacturerAsync(
        [FromRoute] AddBrandsToManufacturerRequestRouteDto routeDto,
        [FromBody] AddBrandsToManufacturerRequestBodyDto bodyDto)
    {
        await Sender.Send(new AddBrandsToManufacturerCommand(routeDto, bodyDto), HttpContext.RequestAborted);

        return NoContent();
    }

    [HttpDelete("{manufacturerId:guid}/brands")]
    public async Task<NoContentResult> DeleteBrandsFromManufacturerAsync(
        [FromRoute] DeleteBrandsToManufacturerRequestRouteDto routeDto,
        [FromBody] DeleteBrandsToManufacturerRequestBodyDto bodyDto)
    {
        await Sender.Send(new DeleteBrandsToManufacturerCommand(routeDto, bodyDto), HttpContext.RequestAborted);

        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<GetManufacturersResponseDto>> GetManufacturersAsync(
        [FromQuery] GetManufacturersRequestQueryDto queryDto)
    {
        return Ok(await Sender.Send(new GetManufacturersQuery(queryDto), HttpContext.RequestAborted));
    }
    
    [HttpGet("{manufacturerId:guid}")]
    public async Task<ActionResult<GetManufacturersResponseDto>> GetManufacturerAsync(
        [FromRoute] GetManufacturerRequestRouteDto routeDto)
    {
        return Ok(await Sender.Send(new GetManufacturerQuery(routeDto), HttpContext.RequestAborted));
    }
}