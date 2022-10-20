using Authentication.BusinessLayer.Settings;

namespace Authentication.Api.Infrastructure.Configurations;

public static class JWTWorkerConfiguration
{
    public static WebApplicationBuilder AddJWTWorkerrSettings(this WebApplicationBuilder applicationBuilder, string prefix = "AuthService_")
    {
        var section = applicationBuilder.Configuration.GetSection(nameof(JWTWorkerSettings));
        applicationBuilder.Services.Configure<JWTWorkerSettings>(applicationBuilder.Configuration.GetSection(nameof(JWTWorkerSettings)));

        return applicationBuilder;
    }
}
