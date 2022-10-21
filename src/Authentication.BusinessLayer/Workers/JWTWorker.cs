using Authentication.BusinessLayer.Interfaces;
using Authentication.BusinessLayer.Settings;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.BusinessLayer.Worker;

/// <summary>
/// Provides methods for verifying and generating jwt.
/// </summary>
/// <seealso cref="Authentication.BusinessLayer.Interfaces.IJWTWorker" />
public class JWTWorker : IJWTWorker
{
    private readonly JWTWorkerSettings _settings;

    /// <summary>
    /// Initializes a new instance of the <see cref="JWTWorker"/> class.
    /// </summary>
    /// <param name="settings">The settings.</param>
    /// <exception cref="System.ArgumentNullException">If <paramref name="settings"/> is null.</exception>
    public JWTWorker(JWTWorkerSettings settings)
    {
        _settings = settings ?? throw new ArgumentNullException(nameof(settings));
    }

    /// <inheritdoc/>
    public Task<string> GenerageToken(string userName, CancellationToken token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_settings.Key);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", userName) }),
            Expires = DateTime.UtcNow.AddHours(_settings.LifeTimeInHours),
            Issuer = _settings.Issuer,
            Audience = _settings.Audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var generatedToken = tokenHandler.CreateToken(tokenDescriptor);
        return Task.FromResult(tokenHandler.WriteToken(generatedToken));
    }

    /// <inheritdoc/>
    public Task<string> ValidateToken(string token, CancellationToken cancellationToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_settings.Key);
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = _settings.Issuer,
            ValidAudience = _settings.Audience,
            ClockSkew = TimeSpan.Zero
        }, out SecurityToken validatedToken);

        var jwtToken = (JwtSecurityToken)validatedToken;
        var userName = jwtToken.Claims.First(x => x.Type == "id").Value;

        return Task.FromResult(userName);
    }
}
