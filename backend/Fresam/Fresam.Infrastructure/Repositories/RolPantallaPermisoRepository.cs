using Dapper;
using Fresam.Application.Interfaces.Repositories;
using Fresam.Domain.Entities;
using Fresam.Infrastructure.Repositories.Base;
using Fresam.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Infrastructure.Repositories;

public class RolPantallaPermisoRepository : BaseRepository, IRolPantallaPermisoRepository
{
    public RolPantallaPermisoRepository(DapperContext context) : base(context)
    {
    }

    public async Task<List<RolPantallaPermiso>> ObtenerTodosAsync()
    {
        using var connection = Context.CreateConnection();

        var sql = @" 
            SELECT 
                RolPantallaPermisoId,
                RolId,
                PantallaPermisoId,
                Activo,
                FechaCreacion,
                UsuarioCreacion,
                FechaModificacion,
                UsuarioModificacion
            FROM RolesPantallasPermisos";

        var result = await connection.QueryAsync<RolPantallaPermiso>(sql);

        return result.ToList();
    }

    public async Task<int> CrearAsync(RolPantallaPermiso rolPantallaPermiso)
    {
        using var connection = Context.CreateConnection();
        var sql = @"
            INSERT INTO RolesPantallasPermisos
            (
                RolId,
                PantallaPermisoId,
                Activo,
                FechaCreacion,
                UsuarioCreacion
            )
            VALUES
            (
                @RolId,
                @PantallaPermisoId,
                @Activo,
                @FechaCreacion,
                @UsuarioCreacion
            );
            SELECT CAST(SCOPE_IDENTITY() as int)";
        var id = await connection.ExecuteScalarAsync<int>(sql, rolPantallaPermiso);
        return id;
    }

    public async Task<int> ActualizarAsync(RolPantallaPermiso rolPantallaPermiso)
    {
        using var connection = Context.CreateConnection();
        var sql = @"
            UPDATE RolesPantallasPermisos
            SET 
                Activo = @Activo,
                FechaModificacion = @FechaModificacion,
                UsuarioModificacion = @UsuarioModificacion
            WHERE RolPantallaPermisoId = @RolPantallaPermisoId;";
        var result = await connection.ExecuteAsync(sql, rolPantallaPermiso);
        return result;
    }

    public async Task<RolPantallaPermiso?> ObtenerPorRolPantallaPermisoAsync(int rolId, int pantallaPermisoId)
    {
        using var connection = Context.CreateConnection();
        var sql = @"
            SELECT 
                RolPantallaPermisoId,
                RolId,
                PantallaPermisoId,
                Activo,
                FechaCreacion,
                UsuarioCreacion,
                FechaModificacion,
                UsuarioModificacion
            FROM RolesPantallasPermisos
            WHERE RolId = @RolId AND PantallaPermisoId = @PantallaPermisoId";
        var result = await connection.QuerySingleOrDefaultAsync<RolPantallaPermiso>(sql, new { RolId = rolId, PantallaPermisoId = pantallaPermisoId });
        return result;
    }
}
