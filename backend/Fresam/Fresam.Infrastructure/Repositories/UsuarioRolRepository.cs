using Fresam.Application.Interfaces.Repositories;
using Fresam.Infrastructure.Data;
using Fresam.Domain.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fresam.Infrastructure.Repositories.Base;

namespace Fresam.Infrastructure.Repositories;

public class UsuarioRolRepository : BaseRepository, IUsuarioRolRepository
{
    public UsuarioRolRepository(DapperContext context) : base(context)
    {
    }

    public async Task<List<UsuarioRol>> ObtenerTodosAsync()
    {
        using var connection = Context.CreateConnection();

        var sql = @"
            SELECT 
                UsuarioRolId,
                UsuarioId,
                RolId,
                Activo,
                FechaCreacion,
                UsuarioCreacion,
                FechaModificacion,
                UsuarioModificacion
            FROM UsuariosRoles";

        var result = await connection.QueryAsync<UsuarioRol>(sql);
    
        return result.ToList();
    }

    public async Task<int> CrearAsync(UsuarioRol usuarioRol)
    {
        using var connection = Context.CreateConnection();
        var sql = @"
            INSERT INTO UsuariosRoles
            (
                UsuarioId,
                RolId,
                Activo,
                FechaCreacion,
                UsuarioCreacion
            )
            VALUES
            (
                @UsuarioId,
                @RolId,
                @Activo,
                @FechaCreacion,
                @UsuarioCreacion
            );
            SELECT CAST(SCOPE_IDENTITY() as int)";
        var id = await connection.ExecuteScalarAsync<int>(sql, usuarioRol);
        return id;
    }

    public async Task<int> ActualizarAsync(UsuarioRol usuarioRol)
    {
        using var connection = Context.CreateConnection();
        var sql = @"
            UPDATE UsuariosRoles
            SET 
                Activo = @Activo,
                FechaModificacion = @FechaModificacion,
                UsuarioModificacion = @UsuarioModificacion
            WHERE UsuarioRolId = @UsuarioRolId;";
        var result = await connection.ExecuteAsync(sql, usuarioRol);
        return result;
    }

    public async Task<UsuarioRol?> ObtenerPorUsuarioRolAsync(int usuarioId, int rolId)
    {
        using var connection = Context.CreateConnection();
        var sql = @"
            SELECT 
                UsuarioRolId,
                UsuarioId,
                RolId,
                Activo,
                FechaCreacion,
                UsuarioCreacion,
                FechaModificacion,
                UsuarioModificacion
            FROM UsuariosRoles
            WHERE UsuarioId = @UsuarioId AND RolId = @RolId";
        var result = await connection.QueryFirstOrDefaultAsync<UsuarioRol>(sql, new { UsuarioId = usuarioId, RolId = rolId });
        return result;
    }
}