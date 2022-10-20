using Authentication.BusinessLayer.Interfaces;
using Authentication.BusinessLayer.Models;

namespace Authentication.BusinessLayer.Services
{
    public class AuthService : IAuthService
    {
        private readonly IJWTWorker _jwtWorker;

        public AuthService(IJWTWorker generator)
        {
            _jwtWorker = generator ?? throw new ArgumentNullException(nameof(generator));
        }

        public Task<string> GenerateToken(User user, CancellationToken token)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return _jwtWorker.GenerageToken(user.Name, token);
        }

        public Task<string> ValidateToken(string token, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException(nameof(token));
            }

            return _jwtWorker.ValidateToken(token, cancellationToken);
        }
    }
}
