using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fresam.Application.Interfaces.Repositories;
using Fresam.Domain.Entities;

namespace Fresam.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    public async Task<List<Usuario>> ObtenerTodosAsync()
    {
        await Task.Delay(100);

        return new List<Usuario>
        {
            new Usuario
            {
                UsuarioId = 1,
                NombreUsuario = "admin",
                NombreCompleto = "Administrador General",
                Correo = "admin@fresam.com",
                PasswordHash = "hashedpassword",
                Activo = true
            }
        };
    }
}
