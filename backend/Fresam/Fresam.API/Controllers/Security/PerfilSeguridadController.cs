using Fresam.Application.Interfaces.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fresam.API.Controllers.Security;

[ApiController]
[Route("api/v1/[controller]")]
public class PerfilSeguridadController : ControllerBase
{
    private readonly IPerfilSeguridadUsuarioService _perfilSeguridadUsuarioService;

    public PerfilSeguridadController(IPerfilSeguridadUsuarioService perfilSeguridadUsuarioService)
    {
        _perfilSeguridadUsuarioService = perfilSeguridadUsuarioService;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> ObtenerPerfil()
    {
        var usuarioIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

        if (usuarioIdClaim == null)
        {
            return Unauthorized();
        }

        int usuarioId = int.Parse(usuarioIdClaim.Value);

        var perfil = await _perfilSeguridadUsuarioService.ObtenerPerfilSeguridadUsuarioAsync(usuarioId);

        return Ok(perfil);
    }
}
