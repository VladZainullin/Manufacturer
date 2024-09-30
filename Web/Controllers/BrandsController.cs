using Application.Contracts.Features.Manufacturers.Commands.AddBrandsToManufacturer;
using Application.Contracts.Features.Manufacturers.Commands.DeleteBrandsFromManufacturer;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/manufacturers/{manufacturerId:guid}/brands")]
public sealed class BrandsController : AppController
{
    [HttpPost]
    public async Task<NoContentResult> AddBrandsToManufacturerAsync(
        [FromRoute] AddBrandsToManufacturerRequestRouteDto routeDto,
        [FromBody] AddBrandsToManufacturerRequestBodyDto bodyDto)
    {
        await Sender.Send(new AddBrandsToManufacturerCommand(routeDto, bodyDto), HttpContext.RequestAborted);

        return NoContent();
    }

    [HttpDelete]
    public async Task<NoContentResult> DeleteBrandsFromManufacturerAsync(
        [FromRoute] DeleteBrandsToManufacturerRequestRouteDto routeDto,
        [FromBody] DeleteBrandsToManufacturerRequestBodyDto bodyDto)
    {
        await Sender.Send(new DeleteBrandsToManufacturerCommand(routeDto, bodyDto), HttpContext.RequestAborted);

        return NoContent();
    }
}