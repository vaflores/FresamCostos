using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fresam.Application.Interfaces.Repositories;
using Fresam.Domain.Entities;
using Fresam.Infrastructure.Repositories.Base;
using Dapper;
using Fresam.Infrastructure.Data;

namespace Fresam.Infrastructure.Repositories;

public class UsuarioRepository : BaseRepository, IUsuarioRepository
{
    
    public UsuarioRepository(DapperContext context) : base(context)
    {
    }

    public async Task<List<Usuario>> ObtenerTodosAsync()
    {
        using var connection = Context.CreateConnection();

        var sql = @"
                SELECT 
                    UsuarioId, 
                    UsuarioNombre, 
                    NombreCompleto, 
                    Correo, 
                    Activo 
                FROM Usuarios";

        var usuarios = await connection.QueryAsync<Usuario>(sql);

        return usuarios.ToList();
    }

    public async Task<int> RegistrarUsuarioAsync(Usuario usuario)
    {
        using var connection = Context.CreateConnection();

        var sql = @"
            INSERT INTO Usuarios 
            (
                EmpleadoId, 
                UsuarioNombre, 
                NombreCompleto, 
                Correo, 
                PasswordHash, 
                Activo, 
                FechaCreacion, 
                UsuarioCreacion
            )
            
            VALUES 
            (
                @EmpleadoId, 
                @UsuarioNombre, 
                @NombreCompleto, 
                @Correo, 
                @PasswordHash,  
                @Activo, 
                @FechaCreacion, 
                @UsuarioCreacion
            );
            
            SELECT CAST(SCOPE_IDENTITY() as int)";

        var usuarioId =
            await connection.ExecuteScalarAsync<int>(sql, usuario);

        return usuarioId;
    }

    public async Task<Usuario?> ObtenerUsuarioPorUsuarioNombreAsync(string usuarioNombre)
    {
        using var connection = Context.CreateConnection();
        var sql = @"
            SELECT 
                UsuarioId,
                EmpleadoId,
                UsuarioNombre,
                NombreCompleto,
                Correo,
                PasswordHash,
                Activo,
                FechaCreacion,
                UsuarioCreacion,
                FechaModificacion,
                UsuarioModificacion
            FROM Usuarios
            WHERE UsuarioNombre = @UsuarioNombre";
        var result = await connection.QuerySingleOrDefaultAsync<Usuario>(sql, new { UsuarioNombre = usuarioNombre });
        return result;
    }

    public async Task<Usuario?> ObtenerUsuarioPorUsuarioIdAsync(int usuarioId)
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
            WHERE UsuarioId = @UsuarioId";

        var usuario = await connection.QueryFirstOrDefaultAsync<Usuario>(
            sql,
            new
            {
                UsuarioId = usuarioId
            });

        return usuario;
    }

    public async Task<int> ActualizarUsuarioPasswordAsync(Usuario usuario)
    {
        using var connection = Context.CreateConnection();
        var sql = @"
            UPDATE Usuarios
            SET 
                PasswordHash = @PasswordHash,
                FechaModificacion = @FechaModificacion,
                UsuarioModificacion = @UsuarioModificacion
            WHERE UsuarioId = @UsuarioId;";
        var result = await connection.ExecuteAsync(sql, usuario);
        return result;
    }
}
