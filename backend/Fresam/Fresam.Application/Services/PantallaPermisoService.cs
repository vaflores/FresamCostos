using Fresam.Application.Interfaces;
using Fresam.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fresam.Application.DTOs.PantallasPermisos;

namespace Fresam.Application.Services;

public class PantallaPermisoService : IPantallaPermisoService
{
    private readonly IPantallaPermisoRepository _pantallaPermisoRepository;

    public PantallaPermisoService(IPantallaPermisoRepository pantallaPermisoRepository)
    {
        _pantallaPermisoRepository = pantallaPermisoRepository;
    }

    public async Task<List<PantallaPermisoDto>> ObtenerTodosAsync()
    {
        var pantallasPermisos = await _pantallaPermisoRepository.ObtenerTodosAsync();
        return pantallasPermisos.Select(pp => new PantallaPermisoDto
        {
            PantallaPermisoId = pp.PantallaPermisoId,
            PantallaId = pp.PantallaId,
            PermisoId = pp.PermisoId,
            Activo = pp.Activo
        }).ToList();
    }

    public async Task<int> CrearAsync(CrearPantallaPermisoDto dto)
    {
        var existe = await _pantallaPermisoRepository.ObtenerPorPantallaPermisoAsync(dto.PantallaId, dto.PermisoId);

        if (existe == null)
        {
            var nuevoPantallaPermiso = new Domain.Entities.PantallaPermiso
            {
                PantallaId = dto.PantallaId,
                PermisoId = dto.PermisoId,
                Activo = true,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = "admin"
            };

            var resultCrear = await _pantallaPermisoRepository.CrearAsync(nuevoPantallaPermiso);
            return resultCrear;

        }

        if (!existe.Activo)
        {
            existe.Activo = true;
            existe.FechaModificacion = DateTime.Now;
            existe.UsuarioModificacion = "admin";

            await _pantallaPermisoRepository.ActualizarAsync(existe);

            return existe.PantallaPermisoId;
        }

        throw new Exception(
            "La pantalla ya tiene asignado este permiso.");
    }
}