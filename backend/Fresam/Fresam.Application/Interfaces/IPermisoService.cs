using Fresam.Application.DTOs.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.Interfaces;

public interface IPermisoService
{
    Task<List<PermisoDto>> ObtenerTodosAsync();

    Task<int> CrearAsync(CrearPermisoDto dto);
}

