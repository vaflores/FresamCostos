using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fresam.Application.DTOs.Usuarios;
using Fresam.Application.Interfaces;
using Fresam.Application.Interfaces.Repositories;

namespace Fresam.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<List<UsuarioDto>> ObtenerTodosAsync()
    {
        var usuarios = await _usuarioRepository
            .ObtenerTodosAsync();

        return usuarios.Select(u => new UsuarioDto
        {
            UsuarioId = u.UsuarioId,
            NombreUsuario = u.NombreUsuario,
            NombreCompleto = u.NombreCompleto,
            Correo = u.Correo,
            Activo = u.Activo
        }).ToList();
    }

}
