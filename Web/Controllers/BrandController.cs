using Application.Contracts.Features.Manufacturers.Commands.UpdateBrand;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/manufacturers/{manufacturerId:guid}/brands/{brandId:guid}")]
public sealed class BrandController : AppController
{
    [HttpPut]
    public async Task<NoContentResult> UpdateBrandAsync(
        [FromRoute] UpdateBrandRequestRouteDto routeDto,
        [FromBody] UpdateBrandRequestBodyDto bodyDto)
    {
        await Sender.Send(new UpdateBrandCommand(routeDto, bodyDto), HttpContext.RequestAborted);

        return NoContent();
    }
}