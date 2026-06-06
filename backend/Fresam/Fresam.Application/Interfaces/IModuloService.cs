using Fresam.Application.DTOs.Modulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.Interfaces;

public interface IModuloService
{
    Task<List<ModuloDto>> ObtenerTodosAsync();
    Task<int> CrearAsync(CrearModuloDto dto);
}

