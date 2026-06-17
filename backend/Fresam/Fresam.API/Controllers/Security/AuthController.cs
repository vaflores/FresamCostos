using Fresam.Application.DTOs.Auth;
using Fresam.Application.Interfaces.Security;
using Fresam.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Fresam.API.Controllers.Security;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{

    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LogingAsync([FromBody] LoginRequestDto request)
    {
        var perfilSeguridadUsuario = await _authService.LoginAsync(request);

        return Ok(perfilSeguridadUsuario);
    }
}
