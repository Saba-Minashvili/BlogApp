using BlogApp.API.Middlewares.RequestResponseLogger.Middleware;

namespace BlogApp.API.Middlewares.RequestResponseLogger.Extensions;


/// <summary>
/// Provides extension methods to add and use the <see cref="RequestResponseLoggerMiddleware"/>.
/// </summary>
public static class RequestResponseLoggerExtension
{
    /// <summary>
    /// Adds the <see cref="RequestResponseLoggerMiddleware"/> to the service collection.
    /// </summary>
    /// <param name="services">The service collection to add the middleware to.></param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection AddRequestResponseLogger(this IServiceCollection services)
    {
        services.AddScoped<RequestResponseLoggerMiddleware>();

        return services;
    }

    /// <summary>
    /// Uses the <see cref="RequestResponseLoggerMiddleware"/> in the application pipeline.
    /// </summary>
    /// <param name="app">The application builder to use the middleware in.</param>
    /// <returns>The application builder.</returns>
    public static IApplicationBuilder UseRequestResponseLogger(this IApplicationBuilder app)
    {
        app.UseMiddleware<RequestResponseLoggerMiddleware>();

        return app;
    }
}
