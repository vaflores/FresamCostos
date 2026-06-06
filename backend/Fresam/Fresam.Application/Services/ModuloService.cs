using Fresam.Application.DTOs.Modulos;
using Fresam.Application.Interfaces;
using Fresam.Application.Interfaces.Repositories;
using Fresam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.Services;

public class ModuloService : IModuloService
{
    private readonly IModuloRepository _moduloRepository;

    public ModuloService(IModuloRepository moduloRepository)
    {
        _moduloRepository = moduloRepository;
    }

    public async Task<List<ModuloDto>> ObtenerTodosAsync()
    {
        var modulos = await _moduloRepository
            .ObtenerTodosAsync();

        return modulos.Select(m => new ModuloDto
        {
            ModuloId = m.ModuloId,
            Nombre = m.Nombre,
            Descripcion = m.Descripcion,
            Icono = m.Icono,
            Orden = m.Orden,
            Activo = m.Activo
        }).ToList();
    }

    public async Task<int> CrearAsync(CrearModuloDto dto)
    {
        var moduloId = await _moduloRepository.CrearAsync(new Modulo
        {
            Nombre = dto.Nombre,
            Descripcion = dto.Descripcion,
            Icono = dto.Icono,
            Orden = dto.Orden,
            Activo = true,
            FechaCreacion = DateTime.Now,
            UsuarioCreacion = "admin"
        });
        return moduloId;
    }
}

