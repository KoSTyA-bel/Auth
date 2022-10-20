using Authentication.BusinessLayer.Interfaces;
using Authentication.BusinessLayer.Models;

namespace Authentication.BusinessLayer.Services;

public class UserService : IUserService
{
    private readonly User _user = new User {
        Name = "Admin",
        Password = "Admin",
    };

    public Task<User> GetUser(string userName, string password, CancellationToken token)
    {
        if ("admin".Equals(userName) && "admin".Equals(password))
        {
            return Task.FromResult(_user);
        }

        return Task.FromResult<User>(null);
    }

    public Task<User> GetUserByName(string userName, CancellationToken token)
    {
        if ("admin".Equals(userName))
        {
            return Task.FromResult(_user);
        }

        return Task.FromResult<User>(null);
    }
}
