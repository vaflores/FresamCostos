using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fresam.Domain.Entities;

namespace Fresam.Application.Interfaces.Repositories;

public interface IRolRepository
{
    Task<List<Rol>> ObtenerTodosAsync();
    Task<int> CrearAsync(Rol rol);
}

