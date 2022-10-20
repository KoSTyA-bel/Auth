using Authentication.BusinessLayer.Generators;
using Authentication.BusinessLayer.Interfaces;
using Authentication.BusinessLayer.Services;
using Authentication.BusinessLayer.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Authentication.BusinessLayer;

public static class BusinessLayerExtensions
{
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

    public static IServiceCollection AddUserService(this IServiceCollection services)
    {
        services
            .AddScoped<IUserService, UserService>();

        return services;
    }
}
