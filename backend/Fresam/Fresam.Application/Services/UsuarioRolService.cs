using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fresam.Application.DTOs.UsuarioRol;
using Fresam.Application.Interfaces;        
using Fresam.Application.Interfaces.Repositories;

namespace Fresam.Application.Services;

public class UsuarioRolService : IUsuarioRolService
{
    private readonly IUsuarioRolRepository _usuarioRolRepository;

    public UsuarioRolService(IUsuarioRolRepository usuarioRolRepository)
    {
        _usuarioRolRepository = usuarioRolRepository;
    }
    
    public async Task<List<UsuarioRolDto>> ObtenerTodosAsync()
    {
        var usuarioRoles = await _usuarioRolRepository.ObtenerTodosAsync();
        return usuarioRoles.Select(ur => new UsuarioRolDto
        {
            UsuarioRolId = ur.UsuarioRolId,
            UsuarioId = ur.UsuarioId,
            RolId = ur.RolId,
            Activo = ur.Activo
        }).ToList();
    }

    public async Task<int> CrearAsync(CrearUsuarioRolDto dto)
    {
        var existe = await _usuarioRolRepository.ObtenerPorUsuarioRolAsync(dto.UsuarioId, dto.RolId);

        if (existe == null)
        {
            var nuevoUsuarioRol = new Domain.Entities.UsuarioRol
            {
                UsuarioId = dto.UsuarioId,
                RolId = dto.RolId,
                Activo = true,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = "admin"
            };

            var resultCrear =  await _usuarioRolRepository.CrearAsync(nuevoUsuarioRol);
            return resultCrear;

        }

        if (!existe.Activo)
        {
            existe.Activo = true;
            existe.FechaModificacion = DateTime.Now;
            existe.UsuarioModificacion = "admin";

            await _usuarioRolRepository.ActualizarAsync(existe);

            return existe.UsuarioRolId;
        }

        throw new Exception(
            "El usuario ya tiene asignado este rol.");
    }

}
