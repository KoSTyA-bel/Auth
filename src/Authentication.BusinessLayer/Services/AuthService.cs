using Authentication.BusinessLayer.Interfaces;
using Authentication.BusinessLayer.Models;

namespace Authentication.BusinessLayer.Services;

/// <summary>
/// Provides methods for verifying and generating jwt.
/// </summary>
/// <seealso cref="Authentication.BusinessLayer.Interfaces.IAuthService" />
public class AuthService : IAuthService
{
    private readonly IJWTWorker _jwtWorker;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthService"/> class.
    /// </summary>
    /// <param name="generator">The generator.</param>
    /// <exception cref="System.ArgumentNullException">If <paramref name="generator"/> is null.</exception>
    public AuthService(IJWTWorker generator)
    {
        _jwtWorker = generator ?? throw new ArgumentNullException(nameof(generator));
    }

    /// <inheritdoc/>
    public Task<string> GenerateToken(User user, CancellationToken token)
    {
        if (user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        return _jwtWorker.GenerageToken(user.Name, token);
    }

    /// <inheritdoc/>
    public Task<string> ValidateToken(string token, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(token))
        {
            throw new ArgumentNullException(nameof(token));
        }

        return _jwtWorker.ValidateToken(token, cancellationToken);
    }
}
