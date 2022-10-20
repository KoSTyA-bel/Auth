using Authentication.BusinessLayer.Models;

namespace Authentication.BusinessLayer.Interfaces;

public interface IAuthService
{
    Task<string> GenerateToken(User user, CancellationToken cancellationToken);

    Task<string> ValidateToken(string token, CancellationToken cancellationToken);
}
