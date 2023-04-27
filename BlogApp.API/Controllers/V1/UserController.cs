using BlogApp.API.Models.Examples.Users;
using BlogApp.Application.Users;
using BlogApp.Application.Users.Requests;
using BlogApp.Application.Users.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace BlogApp.API.Controllers.V1;

/// <summary>
/// Controller for managing users.
/// </summary>
[Route("api/v{version:apiVersion}/users")]
[ApiVersion("1.0")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    /// <summary>
    /// Constructor for UserController.
    /// </summary>
    /// <param name="userService">The user service to use.</param>
    public UserController(IUserService userService) => _userService = userService;

    /// <summary>
    /// Retrieves all users from the database.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET api/v1/users
    ///
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A list of all users.</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<UserResponseModel>), StatusCodes.Status200OK)]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(UsersExample))]
    public async Task<IEnumerable<UserResponseModel>> GetAllUsersAsync(CancellationToken cancellationToken = default)
    {
        return await _userService.GetAllUsersAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves user from database by specific UserId.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET api/v1/users/{userId}
    ///
    /// </remarks>
    /// <param name="userId">The ID of the user to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The user with the specified ID.</returns>
    [HttpGet("{userId}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<UserResponseModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(UserExample))]
    public async Task<UserResponseModel> GetUserByIdAsync(int userId, CancellationToken cancellationToken = default)
    {
        return await _userService.GetUserByIdAsync(userId, cancellationToken);
    }


    /// <summary>
    /// Adds user in the database.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST api/v1/users
    ///     {
    ///         "firstName": "saba",
    ///         "lastName": "minashvili",
    ///         "email": "sabaminashvili04@gmail.com",
    ///         "password": "Saba)4)5@003"
    ///     }
    ///
    /// </remarks>
    /// <param name="request">The UserRequestCreateModel to create the user with.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The ID of the newly-created user.</returns>
    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<int> RegisterUserAsync([FromBody] UserRequestCreateModel request, CancellationToken cancellationToken = default)
    {
        return await _userService.RegisterUserAsync(request, cancellationToken);
    }
}
