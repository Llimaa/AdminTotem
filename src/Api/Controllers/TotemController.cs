using Application.AggregatesModel.TotemAggregate;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("totems")]
public class TotemController : ControllerBase
{
    private readonly TotemHandler handler;
    private readonly ITotemQueries queries;
    public TotemController(TotemHandler handler, ITotemQueries queries)
    {
        this.handler = handler;
        this.queries = queries;
    }

    /// <summary>
    /// Responsible to get all totems
    /// </summary>
    /// <response code="200">return all totems.</response>
    [ProducesResponseType(200)]
    [HttpGet()]
    public async Task<IActionResult> GetAllAsync (CancellationToken cancellationToken) 
    {
        var result =  await queries.GetAllTotemsAsync(cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Responsible to Insert a new Totem.
    /// </summary>
    /// <param name="command">Command with some informations necessary to create a new Totem</param>
    /// <response code="204">Totem added with success.</response>
    [ProducesResponseType(204)]
    [HttpPost()]
    public async Task<IActionResult> InsertAsync (AddTotemCommand command, CancellationToken cancellationToken) 
    {
        await handler.HandlerAsync(command, cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Responsible to remove one totem.
    /// </summary>
    /// <param name="command">Id at totem</param>
    /// <response code="204">Totem removed with success.</response>
    [ProducesResponseType(204)]
    [HttpDelete()]
    public async Task<IActionResult> DeleteAsync (RemoveTotemCommand command, CancellationToken cancellationToken) 
    {
        await handler.HandlerAsync(command, cancellationToken);
        return NoContent();
    }
}