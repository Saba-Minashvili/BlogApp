using BlogApp.Shared.Hasher;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.Shared.Extensions;

public static class PasswordHasherExtension
{
    public static IServiceCollection AddPasswordHasher(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IPasswordHasher<>), typeof(PasswordHasher<>));

        return services;
    }
}
