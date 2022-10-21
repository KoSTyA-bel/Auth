using Authentication.BusinessLayer.Interfaces;
using Authentication.BusinessLayer.Models;

namespace Authentication.BusinessLayer.Services;

/// <summary>
/// Provides methods for working with users.
/// </summary>
/// <seealso cref="Authentication.BusinessLayer.Interfaces.IUserService" />
public class UserService : IUserService
{
    private readonly User _user = new User {
        Name = "Admin",
        Password = "Admin",
    };

    /// <inheritdoc/>
    public Task<User> GetUser(string userName, string password, CancellationToken token)
    {
        if ("admin".Equals(userName) && "admin".Equals(password))
        {
            return Task.FromResult(_user);
        }

        return Task.FromResult<User>(null);
    }
}
