using Fresam.Application.DTOs.Auth;
using Fresam.Application.DTOs.Usuarios;
using Fresam.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fresam.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuariosController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var usuarios = await _usuarioService.ObtenerTodosAsync();
        return Ok(usuarios);
    }

    [HttpPost]
    public async Task<IActionResult> RegistrarUsuario([FromBody] RegistrarUsuarioRequestDto request)
    {
        var usuario = await _usuarioService.RegistrarUsuarioAsync(request);

        return Ok(usuario); 
    }

    [HttpPatch("password")]
    public async Task<IActionResult> ActualizarUsuarioPassword([FromBody] ActualizarUsuarioPasswordRequestDto request)
    {
        var usuario = await _usuarioService.ActualizarUsuarioPasswordAsync(request);

        return Ok(usuario);
    }
}
