using Fresam.Application.DTOs.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.Interfaces;

public interface IRolService
{
    Task<List<RolDto>> ObtenerTodosAsync();

    Task<int> CrearAsync(CrearRolDto dto);
}

