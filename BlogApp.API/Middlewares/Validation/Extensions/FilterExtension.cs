using BlogApp.API.Middlewares.Validation.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Middlewares.Validation.Extensions;

/// <summary>
/// Provides extension methods for configuring filters in an <see cref="IServiceCollection"/>.
/// </summary>
public static class FilterExtension
{
    /// <summary>
    /// Adds filters to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add filters to.</param>
    /// <returns>The same <see cref="IServiceCollection"/> instance that was passed in.</returns>
    public static IServiceCollection AddFilters(this IServiceCollection services)
    {
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        services.AddControllers(options =>
        {
            options.Filters.Add<ValidationFilter>();
        });

        return services;
    }
}
