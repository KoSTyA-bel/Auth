namespace Authentication.BusinessLayer.Interfaces;

/// <summary>
/// Describes methods for jwt worker.
/// </summary>
public interface IJWTWorker
{
    /// <summary>
    /// Generages jwt.
    /// </summary>
    /// <param name="userName">Name of the user.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>JWT.</returns>
    Task<string> GenerageToken(string userName, CancellationToken cancellationToken);

    /// <summary>
    /// Validates jwt.
    /// </summary>
    /// <param name="token">JWT.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>User name from token.</returns>
    Task<string> ValidateToken(string token, CancellationToken cancellationToken);
}
