using Fresam.Application.DTOs.Modulos;
using Fresam.Application.DTOs.Roles;
using Fresam.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fresam.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RolesController : ControllerBase
{
    private readonly IRolService _rolService;

    public RolesController(IRolService rolService)
    {
        _rolService = rolService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var roles = await _rolService.ObtenerTodosAsync();
        return Ok(roles);
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CrearRolDto crearRolDto)
    {
        var rolId = await _rolService.CrearAsync(crearRolDto);
        return Ok(rolId);
    }
}

