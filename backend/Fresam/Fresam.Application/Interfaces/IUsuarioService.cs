using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fresam.Application.DTOs.Usuarios;

namespace Fresam.Application.Interfaces;

public interface IUsuarioService
{
    List<UsuarioDto> ObtenerTodos();
}