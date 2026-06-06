using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fresam.Application.DTOs.Roles;
using Fresam.Application.Interfaces;
using Fresam.Application.Interfaces.Repositories;
using Fresam.Domain.Entities;

namespace Fresam.Application.Services;

public class RolService : IRolService
{
    private readonly IRolRepository _rolRepository;

    public RolService(IRolRepository rolRepository)
    {
        _rolRepository = rolRepository;
    }

    public async Task<List<RolDto>> ObtenerTodosAsync()
    {
        var roles = await _rolRepository.ObtenerTodosAsync();
        return roles.Select(r => new RolDto
        {
            RolId = r.RolId,
            Nombre = r.Nombre,
            Descripcion = r.Descripcion,
            Activo = r.Activo
        }).ToList();
    }

    public async Task<int> CrearAsync(CrearRolDto rolCrearDto)
    {
        var rol = new Rol
        {
            Nombre = rolCrearDto.Nombre,
            Descripcion = rolCrearDto.Descripcion,
            Activo = true,
            FechaCreacion = DateTime.Now,
            UsuarioCreacion = "admin"
        };
        return await _rolRepository.CrearAsync(rol);
    }
}
