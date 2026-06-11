using Fresam.Application.DTOs.UsuarioRol;
using Fresam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.Interfaces.Repositories;

public interface IUsuarioRolRepository
{
    Task<List<UsuarioRol>> ObtenerTodosAsync();

    Task<int> CrearAsync(UsuarioRol usuarioRol);

    Task<int> ActualizarAsync(UsuarioRol usuarioRol);

    Task<UsuarioRol?> ObtenerPorUsuarioRolAsync(int usuarioId, int rolId);
}

