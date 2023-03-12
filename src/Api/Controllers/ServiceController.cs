using Application.AggregatesModel.ServiceAggregate;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("services")]

public class ServiceController : ControllerBase
{
    private readonly ServiceHandler handler;
    private readonly IServiceRepository repository;
    public ServiceController(ServiceHandler handler, IServiceRepository repository)
    {
        this.handler = handler;
        this.repository = repository;
    }

    /// <summary>
    /// Responsible to get all services
    /// </summary>
    /// <response code="200">return all services.</response>
    [ProducesResponseType(200)]
    [HttpGet()]
    public async Task<IActionResult> GetAllAsync (CancellationToken cancellationToken) 
    {
        var result =  await repository.GetAllServiceAsync(cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Responsible to Insert a new Service.
    /// </summary>
    /// <param name="command">Command with some information necessary to create a new service</param>
    /// <response code="204">Service added with success.</response>
    [ProducesResponseType(204)]
    [HttpPost()]
    public async Task<IActionResult> InsertAsync (AddServiceCommand command, CancellationToken cancellationToken) 
    {
        await handler.HandlerAsync(command, cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Responsible to active one service.
    /// </summary>
    /// <param name="command">Id at service</param>
    /// <response code="204">Totem activated with success.</response>
    [ProducesResponseType(204)]
    [HttpPut("/active")]
    public async Task<IActionResult> ActiveAsync (ActiveServiceCommand command, CancellationToken cancellationToken) 
    {
        await handler.HandlerAsync(command, cancellationToken);
        return NoContent();
    }

        /// <summary>
    /// Responsible to inactive one service.
    /// </summary>
    /// <param name="command">Id at service</param>
    /// <response code="204">Totem inactivated with success.</response>
    [ProducesResponseType(204)]
    [HttpPut("/inactive")]
    public async Task<IActionResult> InactiveAsync (InactiveServiceCommand command, CancellationToken cancellationToken) 
    {
        await handler.HandlerAsync(command, cancellationToken);
        return NoContent();
    }
}
