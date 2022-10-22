using Authentication.BusinessLayer.Interfaces;
using Authentication.BusinessLayer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.BusinessLogicTest.Services;

public class UserServiceTest : IClassFixture<RestApiAppBuilder>, IDisposable
{
    private readonly IServiceScope _scope;
    private readonly UserService _userService;

    public UserServiceTest(RestApiAppBuilder builder)
    {
        _scope = builder.Services.CreateScope();
        _userService = _scope.ServiceProvider.GetService(typeof(IUserService)) as UserService;
    }

    private static IEnumerable<(string name, string password)> GetValues()
    {
        yield return (string.Empty, string.Empty);
        yield return (DateTime.Now.ToString(), "password");
        yield return ("123ro48yg3iwiojqr", Guid.Empty.ToString());
    }

    [Fact]
    public void Get_Correct_User_Test()
    {
        var user = _userService.GetUser("admin", "admin", CancellationToken.None).GetAwaiter().GetResult();

        Assert.NotNull(user);
        Assert.Equal("Admin", user.Name);
        Assert.Equal("Admin", user.Password);
    }

    [Fact]
    public void Get_Null()
    {
        foreach (var valuesPair in GetValues())
        {
            var user = _userService.GetUser(valuesPair.name, valuesPair.password, CancellationToken.None).GetAwaiter().GetResult();

            Assert.Null(user);
        }
    }

    public void Dispose()
    {
        _scope.Dispose();
    }
}
