using BlogApp.Application.Users.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace BlogApp.API.Models.Examples.Users;

/// <summary>
/// Provides example for the UserResponseModel class.
/// Implements the IExamplesProvider interface.
/// </summary>
public class UserExample : IExamplesProvider<UserResponseModel>
{
    /// <summary>
    /// Returns an UserResponseModel as an example.
    /// </summary>
    /// <returns>A UserResponseModel class.</returns>
    public UserResponseModel GetExamples()
    {
        return new UserResponseModel
        {
            Id = 1,
            FirstName = "Saba",
            LastName = "Minashvili"
        };
    }
}
