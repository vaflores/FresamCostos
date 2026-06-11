using Fresam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.Interfaces.Repositories;

public interface IRolPantallaPermisoRepository
{
    Task<List<RolPantallaPermiso>> ObtenerTodosAsync();

    Task<int> CrearAsync(RolPantallaPermiso rolPantallaPermiso);

    Task<int> ActualizarAsync(RolPantallaPermiso rolPantallaPermiso);

    Task<RolPantallaPermiso?> ObtenerPorRolPantallaPermisoAsync(int rolId, int pantallaPermisoId);
}
