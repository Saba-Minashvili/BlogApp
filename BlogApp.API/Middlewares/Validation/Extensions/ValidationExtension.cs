using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;

namespace BlogApp.API.Middlewares.Validation.Extensions;

/// <summary>
/// Provides extension methods for configuring validation in an <see cref="IServiceCollection"/>.
/// </summary>
public static class ValidationExtension
{
    /// <summary>
    /// Adds FluentValidation validators to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add validation to.</param>
    /// <returns>The same <see cref="IServiceCollection"/> instance that was passed in.</returns>
    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}