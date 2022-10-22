using Authentication.BusinessLayer.Interfaces;
using Authentication.BusinessLayer.Models;
using Authentication.BusinessLayer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.BusinessLogicTest.Services;

public class AuthServiceTest : IClassFixture<RestApiAppBuilder>, IDisposable
{
    private readonly IServiceScope _scope;
    private readonly AuthService _authService;

    public AuthServiceTest(RestApiAppBuilder builder)
    {
        _scope = builder.Services.CreateScope();
        _authService = _scope.ServiceProvider.GetService(typeof(IAuthService)) as AuthService;
    }

    private static IEnumerable<User> GetUsers()
    {
        yield return new User { Name = "Admin" };
        yield return new User { Name = "Capybara" };
        yield return new User { Name = ".net" };
        yield return new User { Name = "Kostya" };
        yield return new User { Name = "Alex" };
    }

    [Fact]
    public void Correct_Creating_And_Verifyin_JWT()
    {
        foreach (var user in GetUsers())
        {
            var token = _authService.GenerateToken(user, CancellationToken.None).GetAwaiter().GetResult();
            var userNameFromToken = _authService.ValidateToken(token, CancellationToken.None).GetAwaiter().GetResult();

            Assert.Equal(user.Name, userNameFromToken);
        }
    }

    public void Dispose()
    {
        _scope.Dispose();
    }
}
