using Application.AggregatesModel.ServiceDeskAggregate;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("service-desks")]
public class ServiceDeskController: ControllerBase 
{
    private readonly IServiceDeskRepository repository;
    private readonly ServiceDeskHandler handler;

    public ServiceDeskController(IServiceDeskRepository repository, ServiceDeskHandler handler)
    {
        this.repository = repository;
        this.handler = handler;
    }

    /// <summary>
    /// Responsible to get all service desk
    /// </summary>
    /// <response code="200">return all service desk.</response>
    [ProducesResponseType(200)]
    [HttpGet()]
    public async Task<IActionResult> GetAllServiceDeskAsync (CancellationToken cancellationToken) 
    {
        var result =  await repository.GetAllServiceDeskAsync(cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Responsible to Add one service desk
    /// </summary>
    /// <param name="command">Command with some information necessary to create a new Service Desk</param>
    /// <response code="204">Service Desk added with success.</response>
    [ProducesResponseType(204)]
    [HttpPost()]
    public async Task<IActionResult> AddServiceDeskAsync (AddServiceDeskCommand command, CancellationToken cancellationToken) 
    {
        var serviceDesk = new ServiceDesk(command.Name);
        await repository.AddServiceDeskAsync(serviceDesk, cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Responsible to Update one service desk
    /// </summary>
    /// <param name="command">Command with some information necessary to Update a Service Desk</param>
    /// <response code="204">Service Desk updated with success.</response>
    [ProducesResponseType(204)]
    [HttpPut()]
    public async Task<IActionResult> UpdateServiceDeskAsync (UpdateServiceDeskCommand command, CancellationToken cancellationToken) 
    {
        await repository.UpdateServiceDeskAsync(command.Id, command.Name, cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Responsible to Active one service desk
    /// </summary>
    /// <param name="command">Command with some information necessary to active a Service Desk</param>
    /// <response code="204">Service Desk active with success.</response>
    [ProducesResponseType(204)]
    [HttpPatch("/active-services-desk")]
    public async Task<IActionResult> ActiveServiceDeskAsync (ActiveServiceDeskCommand command, CancellationToken cancellationToken) 
    {
        await repository.ActiveServiceDeskAsync(command.Id, (cancellationToken));
        return NoContent();
    }

    /// <summary>
    /// Responsible to Inactive one service desk
    /// </summary>
    /// <param name="command">Command with some information necessary to inactive a Service Desk</param>
    /// <response code="204">Service Desk inactive with success.</response>
    [ProducesResponseType(204)]
    [HttpPatch("/inactive-services-desk")]
    public async Task<IActionResult> InactiveServiceDeskAsync (InactiveServiceDeskCommand command, CancellationToken cancellationToken) 
    {
        await repository.InactiveServiceDeskAsync(command.Id, cancellationToken);
        return NoContent();
    }
}