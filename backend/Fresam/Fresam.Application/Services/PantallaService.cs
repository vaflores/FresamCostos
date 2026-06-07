using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fresam.Application.DTOs.Pantallas;
using Fresam.Application.Interfaces;
using Fresam.Application.Interfaces.Repositories;
using Fresam.Domain.Entities;

namespace Fresam.Application.Services;

public class PantallaService : IPantallaService
{
    private readonly IPantallaRepository _pantallaRepository;

    public PantallaService(IPantallaRepository pantallaRepository)
    {
        _pantallaRepository = pantallaRepository;
    }

    public async Task<List<PantallaDto>> ObtenerTodosAsync()
    {
        var pantallas = await _pantallaRepository.ObtenerTodosAsync();

        return pantallas.Select(p => new PantallaDto
        {
            PantallaId = p.PantallaId,
            Nombre = p.Nombre,
            Descripcion = p.Descripcion,
            Ruta = p.Ruta,
            Icono = p.Icono,
            Orden = p.Orden,
            ModuloId = p.ModuloId,
            Activo = p.Activo
        }).ToList();
    }

    public async Task<int> CrearAsync(CrearPantallaDto dto)
    {
        var pantalla = new Pantalla
        {
            ModuloId = dto.ModuloId,
            Nombre = dto.Nombre.Trim(),
            Descripcion = dto.Descripcion,
            Ruta = dto.Ruta.Trim().ToLower(),
            Icono = dto.Icono,
            Orden = dto.Orden,
            Activo = true,
            FechaCreacion = DateTime.Now,
            UsuarioCreacion = "admin"
        };

        return await _pantallaRepository.CrearAsync(pantalla);
    }
}


