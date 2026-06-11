using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fresam.Application.DTOs.UsuarioRol;

namespace Fresam.Application.Interfaces;

public interface IUsuarioRolService
{
    Task<List<UsuarioRolDto>> ObtenerTodosAsync();

    Task<int> CrearAsync(CrearUsuarioRolDto dto);
}

