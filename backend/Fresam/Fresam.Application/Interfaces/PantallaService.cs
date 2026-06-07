using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fresam.Application.DTOs.Pantallas;

namespace Fresam.Application.Interfaces;

public interface IPantallaService
{
    Task<List<PantallaDto>> ObtenerTodosAsync();
    Task<int> CrearAsync(CrearPantallaDto dto);
}


