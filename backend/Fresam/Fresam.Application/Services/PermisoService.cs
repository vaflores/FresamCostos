using Fresam.Application.DTOs.Permisos;
using Fresam.Application.Interfaces;
using Fresam.Application.Interfaces.Repositories;
using Fresam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.Services;

public class PermisoService : IPermisoService
{
    private readonly IPermisoRepository _permisoRepository;
    public PermisoService(IPermisoRepository permisoRepository)
    {
        _permisoRepository = permisoRepository;
    }
    public async Task<List<PermisoDto>> ObtenerTodosAsync()
    {
        var permisos = await _permisoRepository.ObtenerTodosAsync();

        return permisos.Select(p => new PermisoDto
        {
            PermisoId = p.PermisoId,
            Codigo = p.Codigo,
            Descripcion = p.Descripcion,
            Activo = p.Activo
        }).ToList();

    }

    public async Task<int> CrearAsync(CrearPermisoDto dto)
    {
        var permiso = new Permiso
        {
            Codigo = dto.Codigo.Trim().ToUpper(),
            Descripcion = dto.Descripcion,
            Activo = true,
            FechaCreacion = DateTime.Now,
            UsuarioCreacion = "admin"
        };

        return await _permisoRepository.CrearAsync(permiso);
    }

}
