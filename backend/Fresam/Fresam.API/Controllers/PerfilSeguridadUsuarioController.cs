using Fresam.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fresam.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PerfilSeguridadUsuarioController : ControllerBase
{
    private readonly IPerfilSeguridadUsuarioService _perfilSeguridadService;

    public PerfilSeguridadUsuarioController(IPerfilSeguridadUsuarioService perfilSeguridadService)
    {
        _perfilSeguridadService = perfilSeguridadService;
    }

    [HttpGet("{usuarioId}")]
    public async Task<IActionResult> ObtenerPerfilSeguridadUsaurio(int usuarioId) 
    {
        var perfilSeguridadUsuario = await _perfilSeguridadService.ObtenerPerfilSeguridadUsuarioAsync(usuarioId);

        return Ok(perfilSeguridadUsuario);
    }
}
