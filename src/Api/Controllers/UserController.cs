using Application.AggregatesModel.UserAggregate;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/users")]

public class UserController : ControllerBase
{
    private readonly UserHandler handler;
    private readonly IUserRepository repository;

    public UserController(UserHandler handler, IUserRepository repository)
    {
        this.handler = handler;
        this.repository = repository;
    }

    /// <summary>
    /// Responsible to get one User
    /// </summary>
    /// <param name="document">Document to use to filter user by document</param>
    /// <response code="200">return One User.</response>
    [ProducesResponseType(200)]
    [HttpGet()]
    public async Task<IActionResult> GetUserByDocumentAsync (string document, CancellationToken cancellationToken) 
    {
        var result =  await repository.GetUserByDocumentAsync(document, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Responsible to Add new User
    /// </summary>
    /// <param name="command">Command with some information necessary to create a new User</param>
    /// <response code="202">User added with success</response>
    [ProducesResponseType(202)]
    [HttpPost()]
    public async Task<IActionResult> AddUserAsync (AddUserCommand command, CancellationToken cancellationToken) 
    {
        await handler.HandlerAsync(command, cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Responsible to Active User
    /// </summary>
    /// <param name="command">Command with some information necessary to active User</param>
    /// <response code="202">User activated successfully </response>
    [ProducesResponseType(202)]
    [HttpPatch("/active-user")]
    public async Task<IActionResult> ActiveUserAsync (ActiveUserCommand command, CancellationToken cancellationToken) 
    {
        await handler.HandlerAsync(command, cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Responsible to Inactive User
    /// </summary>
    /// <param name="command">Command with some information necessary to Inactive User</param>
    /// <response code="202">User activated successfully </response>
    [ProducesResponseType(202)]
    [HttpPatch("/inactive-user")]
    public async Task<IActionResult> InActiveUserAsync (InactiveUserCommand command, CancellationToken cancellationToken) 
    {
        await handler.HandlerAsync(command, cancellationToken);
        return NoContent();
    }
}