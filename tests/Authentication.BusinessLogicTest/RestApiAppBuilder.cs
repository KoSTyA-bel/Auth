using Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Authentication.BusinessLogicTest;

public class RestApiAppBuilder : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseSetting("Enviroment", "Integration");
        base.ConfigureWebHost(builder);
    }
}
