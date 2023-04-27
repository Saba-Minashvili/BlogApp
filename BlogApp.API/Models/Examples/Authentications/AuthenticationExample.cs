using BlogApp.Application.Authentication.Models.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace BlogApp.API.Models.Examples.Authentications;

/// <summary>
/// Provides example for the AuthenticationExample class.
/// Implements the IExamplesProvider interface.
/// </summary>
public class AuthenticationExample : IExamplesProvider<AuthenticationResponse>
{
    /// <summary>
    /// Returns an AuthenticationResponse as an example.
    /// </summary>
    /// <returns>A AuthenticationResponse class.</returns>
    public AuthenticationResponse GetExamples()
    {
        return new AuthenticationResponse
        {
            UserId = 1,
            AccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c",
            AccessTokenExpiresMinutes = 10
        };
    }
}