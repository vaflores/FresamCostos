using Microsoft.AspNetCore.Mvc;
using Fresam.Application.Interfaces;
using Fresam.Application.DTOs.UsuarioRol;

namespace Fresam.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UsuariosRolesController : ControllerBase
{
    private readonly IUsuarioRolService _usarioRolService;

    public UsuariosRolesController(IUsuarioRolService usarioRolService)
    {
        _usarioRolService = usarioRolService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var usuariosRoles = await _usarioRolService.ObtenerTodosAsync();
        return Ok(usuariosRoles);
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CrearUsuarioRolDto crearUsuarioRolDto)
    {
        var usuarioRolId = await _usarioRolService.CrearAsync(crearUsuarioRolDto);
        return Ok(usuarioRolId);
    }
}
