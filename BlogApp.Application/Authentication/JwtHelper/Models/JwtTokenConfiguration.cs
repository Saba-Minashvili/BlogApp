namespace BlogApp.Application.Authentication.JwtHelper.Models;

public class JwtTokenConfiguration
{
    public string Issuer { get; set; }

    public string Audience { get; set; }

    public string Secret { get; set; }

    public int AccessTokenExpiresMinutes { get; set; }
}
