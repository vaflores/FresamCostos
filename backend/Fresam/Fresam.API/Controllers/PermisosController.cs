using Fresam.Application.Interfaces;
using Fresam.Application.DTOs.Permisos;
using Microsoft.AspNetCore.Mvc;

namespace Fresam.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PermisosController : ControllerBase
{
    private readonly IPermisoService _permisoService;

    public PermisosController(IPermisoService permisoService)
    {
        _permisoService = permisoService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var permisos = await _permisoService.ObtenerTodosAsync();
        return Ok(permisos);
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CrearPermisoDto crearPermisoDto)
    {
        var permisoId = await _permisoService.CrearAsync(crearPermisoDto);
        return Ok(permisoId);
    }
}
