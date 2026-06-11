using Fresam.Application.DTOs.PantallasPermisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.Interfaces;

public interface IPantallaPermisoService
{
    Task<List<PantallaPermisoDto>> ObtenerTodosAsync();

    Task<int> CrearAsync(CrearPantallaPermisoDto dto);
}

