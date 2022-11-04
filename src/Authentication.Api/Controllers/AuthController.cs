using Authentication.Api.Infrastructure.Attributes;
using Authentication.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;

    public AuthController(IUserService userService, IAuthService authService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
    }

    [HttpPost(Name = "GetToken")]
    [AllowAnonymous]
    public async Task<ActionResult> Get(string userName, string password)
    {
        var user = await _userService.GetUser(userName, password, CancellationToken.None);
        var jwt = await _authService.GenerateToken(user, CancellationToken.None);

        return Ok(new { Token = jwt });
    }

    [HttpGet("Check-token")]
    [Authorize]
    public IActionResult CheckToken()
    {
        return Ok("Token is alive");
    }
}
