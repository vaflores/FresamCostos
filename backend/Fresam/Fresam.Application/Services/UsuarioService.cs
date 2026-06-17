using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fresam.Domain.Entities;
using Fresam.Application.DTOs.Usuarios;
using Fresam.Application.Interfaces;
using Fresam.Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Fresam.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly PasswordHasher<Usuario> _passwordHasher;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
        _passwordHasher = new PasswordHasher<Usuario>();
    }

    public async Task<List<UsuarioDto>> ObtenerTodosAsync()
    {
        var usuarios = await _usuarioRepository
            .ObtenerTodosAsync();

        return usuarios.Select(u => new UsuarioDto
        {
            UsuarioId = u.UsuarioId,
            UsuarioNombre = u.UsuarioNombre,
            NombreCompleto = u.NombreCompleto,
            Correo = u.Correo,
            Activo = u.Activo
        }).ToList();
    }

    public async Task<int> RegistrarUsuarioAsync(RegistrarUsuarioRequestDto dto)
    {
        var existe = await _usuarioRepository.ObtenerUsuarioPorUsuarioNombreAsync(dto.UsuarioNombre);

        if (existe != null)
            throw new InvalidOperationException("Ya existe un usuario con el nombre ingresado");

        if (string.IsNullOrWhiteSpace(dto.Password))
            throw new InvalidOperationException("El password esta vacio");

        var passwordHash = _passwordHasher.HashPassword(new Usuario(), dto.Password);

        var usuario = new Usuario()
        {
            EmpleadoId = dto.EmpleadoId,
            UsuarioNombre = dto.UsuarioNombre,
            NombreCompleto = dto.NombreCompleto,
            Correo = dto.Correo,
            PasswordHash = passwordHash,
            Activo = true,
            FechaCreacion = DateTime.UtcNow,
            UsuarioCreacion = "admin"
        };

        var usuarioId = await _usuarioRepository.RegistrarUsuarioAsync(usuario);

        return usuarioId;
    }

    public async Task<int> ActualizarUsuarioPasswordAsync(ActualizarUsuarioPasswordRequestDto dto)
    {
        var existe = await _usuarioRepository.ObtenerUsuarioPorUsuarioIdAsync(dto.UsuarioId);

        if (existe == null)
            throw new InvalidOperationException("Ya existe un usuario con el nombre ingresado");

        if (string.IsNullOrWhiteSpace(dto.Password))
            throw new InvalidOperationException("El password esta vacio");

        var passwordHash = _passwordHasher.HashPassword(new Usuario(), dto.Password);

        existe.PasswordHash = passwordHash;
        existe.FechaModificacion = DateTime.UtcNow;
        existe.UsuarioModificacion = "admin";

        var filasAfectadas = await _usuarioRepository.ActualizarUsuarioPasswordAsync(existe);

        return filasAfectadas;
    }
}
