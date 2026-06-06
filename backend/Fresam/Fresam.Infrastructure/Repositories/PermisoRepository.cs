using Dapper;
using Fresam.Application.DTOs.Permisos;
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

public class PermisoRepository : BaseRepository, IPermisoRepository
{
    public PermisoRepository(DapperContext context) : base(context)
    {
    }

    public async Task<List<Permiso>> ObtenerTodosAsync()
    {
        using var connection = Context.CreateConnection();
        var sql = @"
                SELECT 
                    PermisoId, 
                    Codigo, 
                    Descripcion,
                    Activo
                FROM Permisos";

        var permisos = await connection.QueryAsync<Permiso>(sql);

        return permisos.ToList();

    }

    public async Task<int> CrearAsync(Permiso permiso)
    {
        using var connection = Context.CreateConnection();

        var sql = @"
            INSERT INTO Permisos 
            (
                Codigo, 
                Descripcion, 
                Activo,
                FechaCreacion,
                UsuarioCreacion
            )
            VALUES 
            (
                @Codigo, 
                @Descripcion,
                @Activo,
                @FechaCreacion,
                @UsuarioCreacion
            );

            SELECT CAST(SCOPE_IDENTITY() as int)";

        var permisoId = await connection.ExecuteScalarAsync<int>(sql, permiso);

        return permisoId;

    }

}


