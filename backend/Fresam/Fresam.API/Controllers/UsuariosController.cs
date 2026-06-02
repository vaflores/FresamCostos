using Microsoft.AspNetCore.Mvc;
using Fresam.Application.Interfaces;

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
    public IActionResult ObtenerTodos()
    {
        var usuarios = _usuarioService.ObtenerTodos();
        return Ok(usuarios);
    }
}
