using Microsoft.AspNetCore.Mvc;
using Fresam.Application.Interfaces;
using Fresam.Application.DTOs.Pantallas;

namespace Fresam.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PantallasController : ControllerBase
{
    private readonly IPantallaService _pantallaService;

    public PantallasController(IPantallaService pantallaService)
    {
        _pantallaService = pantallaService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var pantallas = await _pantallaService.ObtenerTodosAsync();

        return Ok(pantallas);
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CrearPantallaDto crearPantallaDto)
    {
        var pantallaId = await _pantallaService.CrearAsync(crearPantallaDto);
        return Ok(pantallaId);
    }
}
