using BlogApp.Application.Authentication.Models.Requests;
using BlogApp.Application.Authentication.Models.Responses;

namespace BlogApp.Application.Authentication;

public interface IUserAuthentication
{
    Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest authenticationRequest, CancellationToken cancellationToken = default);
}
