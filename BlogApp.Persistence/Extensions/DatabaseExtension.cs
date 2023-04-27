using BlogApp.Persistence.Context;
using BlogApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.Persistence.Extensions;

public static class DatabaseExtension
{
    public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionStrings = configuration.GetSection(ConnectionStringOptions.ConnectionStrings).Get<ConnectionStringOptions>();

        services.AddDbContext<BlogAppDbContext>(options =>
            options.UseSqlServer(connectionStrings.BlogAppDbConnectionString));

        return services;
    }
}
