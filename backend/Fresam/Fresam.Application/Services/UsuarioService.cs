using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fresam.Application.DTOs.Usuarios;
using Fresam.Application.Interfaces;

namespace Fresam.Application.Services;

public class UsuarioService : IUsuarioService
{
    public List<UsuarioDto> ObtenerTodos()
    {
        return new List<UsuarioDto>
        {
            new UsuarioDto
            {
                UsuarioId = 1,
                NombreUsuario = "admin",
                NombreCompleto = "Administrador General",
                Correo = "admin@fresam.com",
                Activo = true
            }
        };
    }
}
