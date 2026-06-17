using Fresam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.Interfaces.Repositories;

public interface IUsuarioRepository
{
    Task<List<Usuario>> ObtenerTodosAsync();

    Task<int> RegistrarUsuarioAsync(Usuario usuario);

    Task<Usuario?> ObtenerUsuarioPorUsuarioNombreAsync(string usuarioNombre);

    Task<Usuario?> ObtenerUsuarioPorUsuarioIdAsync(int usuarioId);

    Task<int> ActualizarUsuarioPasswordAsync(Usuario usuario);
}

