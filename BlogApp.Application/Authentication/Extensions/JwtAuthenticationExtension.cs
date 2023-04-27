using BlogApp.Application.Authentication.JwtHelper.Models;
using BlogApp.Application.Authentication.JwtHelper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BlogApp.Application.Authentication.Extensions;

public static class UserJwtAuthenticationExtension
{
    private static JwtTokenConfiguration _jwtConfig;

    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();

        _jwtConfig = serviceProvider.GetRequiredService<IOptions<JwtTokenConfiguration>>().Value;

        services.AddAuthentication(opt =>
        {
            opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidIssuer = _jwtConfig.Issuer,
                ValidAudience = _jwtConfig.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Secret)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero,
            };
            o.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                {
                    if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                    {
                        context.Response.Headers.Add("IS-TOKEN-EXPIRED", "true");
                    }

                    return Task.CompletedTask;
                },
            };
        });

        return services;
    }

    public static IServiceCollection AddJwtServices(this IServiceCollection services)
    {
        services.AddScoped<IUserAuthentication, UserAuthentication>();
        services.AddScoped<IJwtHelperService, JwtHelperService>();

        return services;
    }

    public static IServiceCollection AddJwtOptionsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtTokenConfiguration>(configuration.GetSection(nameof(JwtTokenConfiguration)));

        return services;
    }
}
