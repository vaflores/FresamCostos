using Fresam.Application.DTOs.Auth;
using Fresam.Application.DTOs.Seguridad;
using Fresam.Application.Interfaces.Repositories.Security;
using Fresam.Application.Interfaces.Security;
using Fresam.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.Services.Security;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly IJwtService _jwtService;
    private readonly PasswordHasher<Usuario> _passwordHasher;
    private readonly IPerfilSeguridadUsuarioService _perfilSeguridadUsuarioService;
    public AuthService(
        IAuthRepository authRepository, 
        IJwtService jwtService, 
        IPerfilSeguridadUsuarioService perfilSeguridadUsuarioService)
    {
        _authRepository = authRepository;
        _jwtService = jwtService;
        _perfilSeguridadUsuarioService = perfilSeguridadUsuarioService;
        _passwordHasher = new PasswordHasher<Usuario>();
    }
    
    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto dto)
    {
        Usuario? usuario = await _authRepository.ObtenerPorNombreUsuarioAsync(dto.Usuario);

        if (usuario == null)
        {
            throw new UnauthorizedAccessException(
                "Usuario o contraseña incorrectos.");
        }

        if (!usuario.Activo)
        {
            throw new UnauthorizedAccessException(
                "Usuario inactivo.");
        }

        PasswordVerificationResult resultado =
            _passwordHasher.VerifyHashedPassword(
                usuario,
                usuario.PasswordHash,
                dto.Password);

        if (resultado == PasswordVerificationResult.Failed)
        {
            throw new UnauthorizedAccessException(
                "Usuario o contraseña incorrectos.");
        }

        var permisosJwt = await ObtenerPermisosJwtAsync(usuario);

        string token = _jwtService.GenerarToken(usuario, permisosJwt);

        return new LoginResponseDto
        {
            UsuarioId = usuario.UsuarioId,
            UsuarioNombre = usuario.UsuarioNombre,
            Token = token
        };
    }

    private async Task<List<string>> ObtenerPermisosJwtAsync(Usuario usuario)
    {
        var perfil = await _perfilSeguridadUsuarioService.ObtenerPerfilSeguridadUsuarioAsync(usuario.UsuarioId);

        var permisosJwt = new List<string>();

        foreach (var modulo in perfil.Modulos)
            foreach (var pantalla in modulo.Pantallas)
                foreach (var permiso in pantalla.Permisos)
                {
                    permisosJwt.Add($"{pantalla.PantallaId}.{permiso.Codigo}");
                }

        permisosJwt = permisosJwt
            .Distinct()
            .ToList();

        return permisosJwt;
    }
}
