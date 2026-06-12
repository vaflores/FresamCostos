using Fresam.Application.DTOs.PantallasPermisos;
using Fresam.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fresam.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PantallasPermisosController : Controller
{
    private readonly IPantallaPermisoService _pantallaPermisoService;

    public PantallasPermisosController(IPantallaPermisoService pantallaPermisoService)
    {
        _pantallaPermisoService = pantallaPermisoService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var pantallasPermisos = await _pantallaPermisoService.ObtenerTodosAsync();
        return Ok(pantallasPermisos);
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CrearPantallaPermisoDto crearPantallaPermisoDto)
    {
        var pantallaPermisoId = await _pantallaPermisoService.CrearAsync(crearPantallaPermisoDto);
        return Ok(pantallaPermisoId);
    }
}
