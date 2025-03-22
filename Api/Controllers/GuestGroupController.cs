using CasamentoLH_Backend.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CasamentoLH_Backend.Api.Controllers;

[ApiController]
[Route("api/groups")]
public class GuestGroupController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetById(
        [FromServices] IGuestGroupService service
    )
    {

        return Ok();
    }
}