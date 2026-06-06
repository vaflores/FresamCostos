using Fresam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.Interfaces.Repositories;

public interface IModuloRepository
{
    Task<List<Modulo>> ObtenerTodosAsync();

    Task<int> CrearAsync(Modulo modulo);
}
