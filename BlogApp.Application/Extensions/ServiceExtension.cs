using BlogApp.Application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.Application.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
