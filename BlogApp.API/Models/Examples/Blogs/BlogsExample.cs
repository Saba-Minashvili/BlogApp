using BlogApp.Application.Blogs.Responses;
using BlogApp.Application.Users.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace BlogApp.API.Models.Examples.Blogs;

/// <summary>
/// Provides examples for the BlogResponseModel class using SwaggerExample.
/// Implements the IMultipleExamplesProvider interface.
/// </summary>
public class BlogsExample : IMultipleExamplesProvider<BlogResponseModel>
{
    /// <summary>
    /// Returns an IEnumerable of SwaggerExample&lt;BlogResponseModel&gt; with two examples.
    /// </summary>
    /// <returns>An IEnumerable of SwaggerExample&lt;BlogResponseModel&gt;.</returns>
    public IEnumerable<SwaggerExample<BlogResponseModel>> GetExamples()
    {
        yield return SwaggerExample.Create("Example 1", new BlogResponseModel
        {
            Id = 1,
            Title = "Test Blog Title",
            Description = "Test Blog Description",
            Authors = new List<UserResponseModel>
            {
                new UserResponseModel
                {
                    Id = 1,
                    FirstName = "Saba",
                    LastName = "Minashvili",
                },
            }
        });

        yield return SwaggerExample.Create("Example 2", new BlogResponseModel
        {
            Id = 1,
            Title = "Title",
            Description = "Description",
            Authors = new List<UserResponseModel>
            {
                new UserResponseModel
                {
                    Id = 2,
                    FirstName = "FirstName",
                    LastName = "LastName",
                },
            }
        });
    }
}
