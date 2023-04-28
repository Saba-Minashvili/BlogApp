using BlogApp.API.Models.Examples.Blogs;
using BlogApp.API.Models.Examples.Users;
using BlogApp.Application.Blogs;
using BlogApp.Application.Blogs.Requests;
using BlogApp.Application.Blogs.Responses;
using BlogApp.Application.Users.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace BlogApp.API.Controllers.V1;

/// <summary>
/// Controller for managing Blogs.
/// </summary>
[Route("api/v{version:apiVersion}/blogs")]
[ApiVersion("1.0")]
[ApiController]
[Authorize]
public class BlogController : ControllerBase
{
    private readonly IBlogService _blogService;

    /// <summary>
    /// Constructor for BlogController.
    /// </summary>
    /// <param name="blogService">The blog service to use.</param>
    public BlogController(IBlogService blogService) => _blogService = blogService;

    /// <summary>
    /// Retrieves all blogs from the database.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET api/v1/blogs
    ///
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A list of all blogs.</returns>
    [HttpGet]
    [AllowAnonymous]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<BlogResponseModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(BlogsExample))]
    public async Task<IEnumerable<BlogResponseModel>> GetAllBlogsAsync(CancellationToken cancellationToken = default)
    {
        return await _blogService.GetAllBlogsAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves all blogs from the database for currently authorized user.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET api/v1/blogs/by-user
    ///
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A list of all blogs.</returns>
    [HttpGet("by-user")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<BlogResponseModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(BlogsExample))]
    public async Task<IEnumerable<BlogResponseModel>> GetAllBlogsByUserIdAsync(CancellationToken cancellationToken = default)
    {
        return await _blogService.GetAllBlogsByUserIdAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves blog from database by specific UserId.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET api/v1/blog/{blogId}
    ///
    /// </remarks>
    /// <param name="blogId">The ID of the blog to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The blog with the specified ID.</returns>
    [HttpGet("{blogId}")]
    [AllowAnonymous]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<BlogResponseModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(BlogExample))]
    public async Task<BlogResponseModel> GetBlogByIdAsync(int blogId, CancellationToken cancellationToken = default)
    {
        return await _blogService.GetBlogByIdAsync(blogId, cancellationToken);
    }

    /// <summary>
    /// Adds blog in the database.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST api/v1/blogs
    ///     {
    ///         "title": "Test Blog Title",
    ///         "description": "Test Blog Description",
    ///         "users": [
    ///             "sabaminashvili04@gmail.com"
    ///         ]
    ///     }
    ///
    /// </remarks>
    /// <param name="request">The BlogRequestCreateModel to create the blog with.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The ID of the newly-created blog.</returns>
    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<int> CreateBlogAsync([FromBody] BlogRequestCreateModel request, CancellationToken cancellationToken = default)
    {
        return await _blogService.CreateBlogAsync(request, cancellationToken);
    }

    /// <summary>
    /// Updates blog in the database.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT api/v1/blogs/{blogId}
    ///     {
    ///         "title": "Updated Test Blog Title",
    ///         "description": "Updated Test Blog Description"
    ///     }
    ///
    /// </remarks>
    /// <param name="blogId">The Id of the blog we are going to update.</param>
    /// <param name="request">The BlogRequestUpdateModel to update the blog with.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Whether operation was successfull or not.</returns>
    [HttpPut("{blogId}")]
    public async Task<bool> UpdateBlogAsync(int blogId, [FromBody] BlogRequestUpdateModel request, CancellationToken cancellationToken = default)
    {
        return await _blogService.UpdateBlogAsync(blogId, request, cancellationToken);
    }

    /// <summary>
    /// Deletes blog in the database.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE api/v1/blogs/{blogId}
    ///     {
    ///         "title": "Updated Test Blog Title",
    ///         "description": "Updated Test Blog Description"
    ///     }
    ///
    /// </remarks>
    /// <param name="blogId">The Id of the blog we are going to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Whether operation was successfull or not.</returns>
    [HttpDelete("{blogId}")]
    public async Task DeleteBlogAsync(int blogId, CancellationToken cancellationToken = default)
    {
        await _blogService.DeleteBlogAsync(blogId, cancellationToken);
    }
}
