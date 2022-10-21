using Authentication.BusinessLayer.Models;

namespace Authentication.BusinessLayer.Interfaces;

/// <summary>
/// Describes methods for authentification service.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Generates the jwt.
    /// </summary>
    /// <param name="user">The user.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>JWT.</returns>
    Task<string> GenerateToken(User user, CancellationToken cancellationToken);

    /// <summary>
    /// Validates the jwt.
    /// </summary>
    /// <param name="token">JWT.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>User name from jwt.</returns>
    Task<string> ValidateToken(string token, CancellationToken cancellationToken);
}
