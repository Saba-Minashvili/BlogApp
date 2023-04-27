using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.Infrastructure.Extensions;

public static class UnitOfWorkExtension
{
    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
