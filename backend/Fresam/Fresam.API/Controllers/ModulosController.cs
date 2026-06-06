using Microsoft.AspNetCore.Mvc;
using Fresam.Application.Interfaces;
using Fresam.Application.DTOs.Modulos;

namespace Fresam.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ModulosController : ControllerBase
{
    private readonly IModuloService _moduloService;

    public ModulosController(IModuloService moduloService)
    {
        _moduloService = moduloService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var modulos = await _moduloService.ObtenerTodosAsync();
        return Ok(modulos);
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CrearModuloDto crearModuloDto)
    {
        var moduloId = await _moduloService.CrearAsync(crearModuloDto);
        return Ok(moduloId);
    }
}
