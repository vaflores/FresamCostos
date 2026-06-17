using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fresam.Application.DTOs.Seguridad;

namespace Fresam.Application.Interfaces.Repositories.Security;

public interface IPerfilSeguridadUsuarioRepository
{
    Task<List<PerfilSeguridadUsuarioRowDto>> ObtenerPerfilSeguridadUsuarioAsync(int usuarioId);
}
