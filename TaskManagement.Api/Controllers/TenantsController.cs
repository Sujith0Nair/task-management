using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Features.Tenants.Commands;

namespace TaskManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TenantsController(CreateTenantCommandHandler createTenantHandler) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateTenant([FromBody] CreateTenantCommand command)
    {
        var tenantId = await createTenantHandler.Handle(command, CancellationToken.None);
        return Ok(tenantId);
    }
}