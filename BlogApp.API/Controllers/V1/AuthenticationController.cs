using BlogApp.Application.Authentication.Models.Requests;
using BlogApp.Application.Authentication.Models.Responses;
using BlogApp.Application.Authentication;
using Microsoft.AspNetCore.Mvc;
using BlogApp.API.Models.Examples.Authentications;
using Swashbuckle.AspNetCore.Filters;

namespace BlogApp.API.Controllers.V1;

/// <summary>
/// Controller which is responsible for user authentication.
/// </summary>
[Route("api/v{version:apiVersion}/users")]
[ApiVersion("1.0")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IUserAuthentication _userAuthentication;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthenticationController"/> class with the specified dependencies.
    /// </summary>
    /// <param name="userAuthentication"></param>
    public AuthenticationController(IUserAuthentication userAuthentication)
    {
        _userAuthentication = userAuthentication;
    }

    /// <summary>
    /// Authenticates the user.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST api/v1/users/access-token
    ///     {
    ///         "email": "sabaminashvili04@gmail.com",
    ///         "password": "Saba)4)5@003"
    ///     }
    ///
    /// </remarks>
    /// <param name="request">The authentication request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>An <see cref="AuthenticationResponse"/>.</returns>
    [HttpPost]
    [Route("access-token")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<AuthenticationResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(AuthenticationExample))]
    public async Task<AuthenticationResponse> Authenticate([FromBody] AuthenticationRequest request, CancellationToken cancellationToken = default)
    {
        return await _userAuthentication.AuthenticateAsync(request, cancellationToken);
    }
}
