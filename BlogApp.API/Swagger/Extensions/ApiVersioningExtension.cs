using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Swagger.Extensions;

/// <summary>
/// Extension class to implement API versioning in an IServiceCollection.
/// </summary>
public static class ApiVersioningExtension
{
    /// <summary>
    /// Adds API versioning to an IServiceCollection
    /// </summary>
    /// <param name="services">The IServiceCollection to add API versioning to.</param>
    /// <returns>The modified IServiceCollection.</returns>
    public static IServiceCollection ImplementApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
        });

        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        return services;
    }
}
