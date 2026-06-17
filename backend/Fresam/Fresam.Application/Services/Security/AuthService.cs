using Fresam.Application.DTOs.Auth;
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
    public AuthService(IAuthRepository authRepository, IJwtService jwtService)
    {
        _authRepository = authRepository;
        _jwtService = jwtService;
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

        string token = _jwtService.GenerarToken(usuario);

        return new LoginResponseDto
        {
            UsuarioId = usuario.UsuarioId,
            UsuarioNombre = usuario.UsuarioNombre,
            Token = token
        };
    }
}
