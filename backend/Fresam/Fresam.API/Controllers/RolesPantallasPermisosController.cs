using Fresam.Application.DTOs.RolesPantallasPermisos;
using Fresam.Application.Interfaces;
using Fresam.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fresam.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RolesPantallasPermisosController : ControllerBase
{
    private readonly IRolPantallaPermisoService _rolPantallaPermisoService;
    public RolesPantallasPermisosController(IRolPantallaPermisoService rolPantallaPermisoService)
    {
        _rolPantallaPermisoService = rolPantallaPermisoService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var rolPantallasPermisos = await _rolPantallaPermisoService.ObtenerTodosAsync();
        return Ok(rolPantallasPermisos);
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CrearRolPantallaPermisoDto crearPantallaPermisoDto)
    {
        var pantallaPermisoId = await _rolPantallaPermisoService.CrearAsync(crearPantallaPermisoDto);
        return Ok(pantallaPermisoId);
    }
}
