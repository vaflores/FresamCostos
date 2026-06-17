using Dapper;
using Fresam.Application.DTOs.Auth;
using Fresam.Application.Interfaces.Repositories.Security;
using Fresam.Domain.Entities;
using Fresam.Infrastructure.Data;
using Fresam.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Infrastructure.Repositories;

public class AuthRepository : BaseRepository, IAuthRepository
{
    public AuthRepository(DapperContext context) : base(context)
    {
    }

    public async Task<Usuario?> ObtenerPorNombreUsuarioAsync(string usuarioNombre)
    {
        using var connection = Context.CreateConnection();

        var sql = @"
            SELECT
                UsuarioId,
                UsuarioNombre,
                NombreCompleto,
                Correo,
                PasswordHash,
                Activo
            FROM Usuarios
            WHERE UsuarioNombre = @UsuarioNombre";

        var usuario = await connection.QueryFirstOrDefaultAsync<Usuario>(
            sql,
            new
            {
                UsuarioNombre = usuarioNombre
            });

        return usuario;
    }
}
