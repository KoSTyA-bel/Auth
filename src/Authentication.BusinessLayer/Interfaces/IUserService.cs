using Authentication.BusinessLayer.Models;

namespace Authentication.BusinessLayer.Interfaces;

/// <summary>
/// Describes methods for user service.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Gets the user.
    /// </summary>
    /// <param name="userName">Name of the user.</param>
    /// <param name="password">The password.</param>
    /// <param name="token">The token.</param>
    /// <returns>User.</returns>
    Task<User> GetUser(string userName, string password, CancellationToken token);
}
