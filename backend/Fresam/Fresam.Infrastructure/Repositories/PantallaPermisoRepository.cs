using Dapper;
using Fresam.Application.DTOs.PantallasPermisos;
using Fresam.Application.Interfaces.Repositories;
using Fresam.Domain.Entities;
using Fresam.Infrastructure.Data;
using Fresam.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fresam.Infrastructure.Repositories;

public class PantallaPermisoRepository : BaseRepository, IPantallaPermisoRepository
{
    public PantallaPermisoRepository(DapperContext context) : base(context)
    {
    }

    public async Task<List<PantallaPermiso>> ObtenerTodosAsync()
    {
        using var connection = Context.CreateConnection();

        var sql = @" 
            SELECT 
                PantallaPermisoId,
                PantallaId,
                PermisoId,
                Activo,
                FechaCreacion,
                UsuarioCreacion,
                FechaModificacion,
                UsuarioModificacion
            FROM PantallasPermisos";

        var result = await connection.QueryAsync<PantallaPermiso>(sql);

        return result.ToList();
    }

    public async Task<int> CrearAsync(PantallaPermiso pantallaPermiso)
    {
        using var connection = Context.CreateConnection();
        var sql = @"
            INSERT INTO PantallasPermisos
            (
                PantallaId,
                PermisoId,
                Activo,
                FechaCreacion,
                UsuarioCreacion
            )
            VALUES
            (
                @PantallaId,
                @PermisoId,
                @Activo,
                @FechaCreacion,
                @UsuarioCreacion
            );
            SELECT CAST(SCOPE_IDENTITY() as int)";
        var id = await connection.ExecuteScalarAsync<int>(sql, pantallaPermiso);
        return id;
    }

    public async Task<int> ActualizarAsync(PantallaPermiso pantallaPermiso)
    {
        using var connection = Context.CreateConnection();
        var sql = @"
            UPDATE PantallasPermisos
            SET 
                Activo = @Activo,
                FechaModificacion = @FechaModificacion,
                UsuarioModificacion = @UsuarioModificacion
            WHERE PantallaPermisoId = @PantallaPermisoId;";
        var result = await connection.ExecuteAsync(sql, pantallaPermiso);
        return result;
    }

    public async Task<PantallaPermiso?> ObtenerPorPantallaPermisoAsync(int pantallaId, int permisoId)
    {
        using var connection = Context.CreateConnection();
        var sql = @"
            SELECT 
                PantallaPermisoId,
                PantallaId,
                PermisoId,
                Activo,
                FechaCreacion,
                UsuarioCreacion,
                FechaModificacion,
                UsuarioModificacion
            FROM PantallasPermisos
            WHERE PantallaId = @PantallaId AND PermisoId = @PermisoId";
        var result = await connection.QueryFirstOrDefaultAsync<PantallaPermiso>(sql, new { PantallaId = pantallaId, PermisoId = permisoId });
        return result;
    }
}


