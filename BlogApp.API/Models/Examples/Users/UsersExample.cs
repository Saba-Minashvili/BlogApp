using BlogApp.Application.Users.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace BlogApp.API.Models.Examples.Users;

/// <summary>
/// Provides examples for the EventResponseModel class using SwaggerExample.
/// Implements the IMultipleExamplesProvider interface.
/// </summary>
public class UsersExample : IMultipleExamplesProvider<UserResponseModel>
{
    /// <summary>
    /// Returns an IEnumerable of SwaggerExample&lt;UserResponseModel&gt; with two examples.
    /// </summary>
    /// <returns>An IEnumerable of SwaggerExample&lt;UserResponseModel&gt;.</returns>
    public IEnumerable<SwaggerExample<UserResponseModel>> GetExamples()
    {
        yield return SwaggerExample.Create("Example 1", new UserResponseModel
        {
            Id = 1,
            FirstName = "Saba",
            LastName = "Minashvili"
        });

        yield return SwaggerExample.Create("Example 2", new UserResponseModel
        {
            Id = 2,
            FirstName = "FirstName",
            LastName = "LastName"
        });
    }
}
