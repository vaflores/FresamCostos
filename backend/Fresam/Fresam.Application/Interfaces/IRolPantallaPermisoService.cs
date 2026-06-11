using Fresam.Application.DTOs.RolesPantallasPermisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.Interfaces;

public interface IRolPantallaPermisoService
{
    Task<List<RolPantallaPermisoDto>> ObtenerTodosAsync();
    Task<int> CrearAsync(CrearRolPantallaPermisoDto dto);
}
