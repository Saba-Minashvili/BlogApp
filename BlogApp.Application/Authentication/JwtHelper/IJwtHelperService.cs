using BlogApp.Application.Authentication.Models.Responses;

namespace BlogApp.Application.Authentication.JwtHelper;

public interface IJwtHelperService
{
    Task<AuthenticationResponse> CreateTokenAsync(int userId, string email);
}
