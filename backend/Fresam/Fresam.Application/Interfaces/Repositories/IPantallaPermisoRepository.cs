using Fresam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.Interfaces.Repositories;

public interface IPantallaPermisoRepository
{
    Task<List<PantallaPermiso>> ObtenerTodosAsync();

    Task<int> CrearAsync(PantallaPermiso pantallaPermiso);

    Task<int> ActualizarAsync(PantallaPermiso pantallaPermiso);

    Task<PantallaPermiso?> ObtenerPorPantallaPermisoAsync(int pantallaId, int permisoId);
}


