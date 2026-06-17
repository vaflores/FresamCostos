using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fresam.Application.DTOs.Usuarios;

namespace Fresam.Application.Interfaces;

public interface IUsuarioService
{
    Task<List<UsuarioDto>> ObtenerTodosAsync();

    Task<int> RegistrarUsuarioAsync(RegistrarUsuarioRequestDto dto);

    Task<int> ActualizarUsuarioPasswordAsync(ActualizarUsuarioPasswordRequestDto dto);
}