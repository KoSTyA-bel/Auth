using Authentication.BusinessLayer.Worker;
using Authentication.BusinessLayer.Interfaces;
using Authentication.BusinessLayer.Services;
using Authentication.BusinessLayer.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Authentication.BusinessLayer;

/// <summary>
/// Expands functionality of service collection.
/// </summary>
public static class BusinessLayerExtensions
{
    /// <summary>
    /// Adds a traciented and singleton serivices to the service collection.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <returns>Service collection.</returns>
    public static IServiceCollection AddAuthService(this IServiceCollection services)
    {
        services
            .AddTransient<IAuthService, AuthService>()
            .AddTransient<IJWTWorker, JWTWorker>()
            .AddSingleton(GetJWTWorkerSettings);

        return services;

        static JWTWorkerSettings GetJWTWorkerSettings(IServiceProvider sp)
        {
            var settings = sp.GetRequiredService<IOptions<JWTWorkerSettings>>().Value;
            return settings;
        }
    }

    /// <summary>
    /// Adds a scoped serivice to the service collection.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <returns>Service collection.</returns>
    public static IServiceCollection AddUserService(this IServiceCollection services)
    {
        services
            .AddScoped<IUserService, UserService>();

        return services;
    }
}
