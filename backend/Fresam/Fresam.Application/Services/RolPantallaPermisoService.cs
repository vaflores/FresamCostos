using Fresam.Application.DTOs.RolesPantallasPermisos;
using Fresam.Application.Interfaces.Repositories;
using Fresam.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.Services;

public class RolPantallaPermisoService : IRolPantallaPermisoService
{
    private readonly IRolPantallaPermisoRepository _rolPantallaPermisoRepository;

    public RolPantallaPermisoService(IRolPantallaPermisoRepository rolPantallaPermisoRepository)
    {
        _rolPantallaPermisoRepository = rolPantallaPermisoRepository;
    }

    public async Task<List<RolPantallaPermisoDto>> ObtenerTodosAsync()
    {
        var rolesPantallasPermisos = await _rolPantallaPermisoRepository.ObtenerTodosAsync();
        return rolesPantallasPermisos.Select(rpp => new RolPantallaPermisoDto
        {
            RolPantallaPermisoId = rpp.RolPantallaPermisoId,
            RolId = rpp.RolId,
            PantallaPermisoId = rpp.PantallaPermisoId,
            Activo = rpp.Activo
        }).ToList();
    }

    public async Task<int> CrearAsync(CrearRolPantallaPermisoDto dto)
    {
        var existe = await _rolPantallaPermisoRepository.ObtenerPorRolPantallaPermisoAsync(dto.RolId, dto.PantallaPermisoId);

        if (existe == null)
        {
            var nuevoRolPantallaPermiso = new Domain.Entities.RolPantallaPermiso
            {
                RolId = dto.RolId,
                PantallaPermisoId = dto.PantallaPermisoId,
                Activo = true,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = "admin"
            };

            var resultCrear = await _rolPantallaPermisoRepository.CrearAsync(nuevoRolPantallaPermiso);
            return resultCrear;

        }

        if (!existe.Activo)
        {
            existe.Activo = true;
            existe.FechaModificacion = DateTime.Now;
            existe.UsuarioModificacion = "admin";

            await _rolPantallaPermisoRepository.ActualizarAsync(existe);

            return existe.RolPantallaPermisoId;
        }

        throw new Exception(
            "La rol ya tiene asignado este permiso para la pantalla.");
    }
}
