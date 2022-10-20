using Authentication.BusinessLayer.Interfaces;

namespace Authentication.Api.Infrastructure.Middlewares;

public class JWTMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IAuthService _authService;

    public JWTMiddleware(RequestDelegate next, IAuthService authService)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
        {
            await AttachAccountToContext(context, token);
        }

        await _next(context);
    }

    private async Task AttachAccountToContext(HttpContext context, string token)
    {
        try
        {
            var userName = await _authService.ValidateToken(token, CancellationToken.None);

            context.Items["User"] = userName;
        }
        catch
        {
            // do nothing if jwt validation fails
        }
    }
}
