namespace BlogApp.Application.Authentication.Models.Responses;

public class AuthenticationResponse
{
    public int UserId { get; set; }

    public string AccessToken { get; set; }

    public int AccessTokenExpiresMinutes { get; set; }
}
