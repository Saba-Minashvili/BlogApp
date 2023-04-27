using BlogApp.API.Middlewares.ExceptionHandler.Middleware;

namespace BlogApp.API.Middlewares.ExceptionHandler.Extensions;

/// <summary>
/// Extensions methods for handling global exceptions.
/// </summary>
public static class ExceptionHandlerExtension
{
    /// <summary>
    /// Adds the <see cref="GlobalExceptionHandlerMiddleware"/> to the dependency injection container.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance to add the middleware to.</param>
    /// <returns>The updated <see cref="IServiceCollection"/> instance.</returns>
    public static IServiceCollection AddGlobalExceptionHandler(this IServiceCollection services)
    {
        services.AddScoped<GlobalExceptionHandlerMiddleware>();

        return services;
    }

    /// <summary>
    /// Uses the <see cref="GlobalExceptionHandlerMiddleware"/> to handle global exceptions.
    /// </summary>
    /// <param name="builder">The <see cref="IApplicationBuilder"/> instance to add the middleware to.</param>
    /// <returns>The updated <see cref="IApplicationBuilder"/> instance.</returns>
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<GlobalExceptionHandlerMiddleware>();

        return builder;
    }
}
