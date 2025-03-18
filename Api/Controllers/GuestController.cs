using System.Threading.Tasks;
using CasamentoLH_Backend.Api.Payloads;
using CasamentoLH_Backend.Domain.Models;
using CasamentoLH_Backend.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CasamentoLH_Backend.Api.Controllers;

[ApiController]
[Route("api/guests")]
public class GuestController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<GuestDTO>> CreateManyGuests(
        [FromServices] IGuestService service, [FromBody] IEnumerable<GuestGroupPayload> payload
    )
    {
        var result = await service.CreateManyGuests(payload);
        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> Remove(
        [FromServices] IGuestService service, Guid id
    )
    {
        await service.Delete(id);
        return NoContent();
    }
}