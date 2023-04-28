using BlogApp.Application.Blogs.Responses;
using BlogApp.Application.Users.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace BlogApp.API.Models.Examples.Blogs;

/// <summary>
/// Provides example for the BlogResponseModel class.
/// Implements the IExamplesProvider interface.
/// </summary>
public class BlogExample : IExamplesProvider<BlogResponseModel>
{
    /// <summary>
    /// Returns an BlogResponseModel as an example.
    /// </summary>
    /// <returns>A BlogResponseModel class.</returns>
    public BlogResponseModel GetExamples()
    {
        return new BlogResponseModel
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
        };
    }
}
