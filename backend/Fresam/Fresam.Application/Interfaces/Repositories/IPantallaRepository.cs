using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fresam.Domain.Entities;

namespace Fresam.Application.Interfaces.Repositories;

public interface IPantallaRepository
{
    Task<List<Pantalla>> ObtenerTodosAsync();
    Task<int> CrearAsync(Pantalla crearPantallaDto);
}

