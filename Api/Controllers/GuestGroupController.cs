using CasamentoLH_Backend.Api.Payloads;
using CasamentoLH_Backend.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CasamentoLH_Backend.Api.Controllers;

[ApiController]
[Route("api/groups")]
public class GuestGroupController : ControllerBase
{
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> GetById(
        [FromServices] IGuestGroupService service, Guid id
    )
    {
        var result = await service.GetById(id);
        return Ok(result);
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<ActionResult> ConfirmAttendance(
        [FromServices] IGuestGroupService service, [FromBody] IEnumerable<ConfirmAttendancePayload> payload, Guid id
    )
    {
        var result = await service.ConfirmAttendance(id, payload);
        return Ok(result);
    }
}