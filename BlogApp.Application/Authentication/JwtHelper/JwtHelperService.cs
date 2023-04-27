using BlogApp.Application.Authentication.JwtHelper.Models;
using BlogApp.Application.Authentication.Models.Responses;
using BlogApp.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogApp.Application.Authentication.JwtHelper;

public class JwtHelperService : IJwtHelperService
{
    private readonly JwtTokenConfiguration _jwtConfig;
    private readonly IUnitOfWork _unitOfWork;

    public JwtHelperService(IOptions<JwtTokenConfiguration> jwtOptions, IUnitOfWork unitOfWork)
    {
        _jwtConfig = jwtOptions.Value;
        _unitOfWork = unitOfWork;
    }

    public async Task<AuthenticationResponse> CreateTokenAsync(int userId, string email)
    {
        var issuer = _jwtConfig.Issuer;
        var auidence = _jwtConfig.Audience;
        var key = Encoding.UTF8.GetBytes(_jwtConfig.Secret);

        var claims = new List<Claim>
        {
            new Claim("UserId", userId.ToString()),
        };

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_jwtConfig.AccessTokenExpiresMinutes),
            Issuer = issuer,
            Audience = auidence,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var accessToken = tokenHandler.WriteToken(token);

        var user = await _unitOfWork.UserRepository.GetByEmailAsync(email);

        return new AuthenticationResponse()
        {
            UserId = user.Id,
            AccessToken = accessToken,
            AccessTokenExpiresMinutes = _jwtConfig.AccessTokenExpiresMinutes,
        };
    }
}
