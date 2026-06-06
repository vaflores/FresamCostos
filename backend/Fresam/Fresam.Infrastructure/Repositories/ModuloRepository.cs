using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Fresam.Application.Interfaces.Repositories;
using Fresam.Domain.Entities;
using Fresam.Infrastructure.Data;
using Fresam.Infrastructure.Repositories.Base;

namespace Fresam.Infrastructure.Repositories;

public class ModuloRepository : BaseRepository, IModuloRepository
{
    public ModuloRepository(DapperContext context) : base(context)
    {
    }

    public async Task<List<Modulo>> ObtenerTodosAsync()
    {
        using var connection = Context.CreateConnection();

        var sql = @"
            SELECT
                ModuloId,
                Nombre,
                Descripcion,
                Icono,
                Orden,
                Activo,
                FechaCreacion,
                UsuarioCreacion,
                FechaModificacion,
                UsuarioModificacion
            FROM Modulos
            ORDER BY Orden";

        var modulos = await connection.QueryAsync<Modulo>(sql);

        return modulos.ToList();
    }

    public async Task<int> CrearAsync(Modulo modulo)
    {
        using var connection = Context.CreateConnection();

        var sql = @"
            INSERT INTO Modulos
            (
                Nombre,
                Descripcion,
                Icono,
                Orden,
                Activo,
                FechaCreacion,
                UsuarioCreacion
            )
            VALUES
            (
                @Nombre,
                @Descripcion,
                @Icono,
                @Orden,
                @Activo,
                @FechaCreacion,
                @UsuarioCreacion
            );

            SELECT CAST(SCOPE_IDENTITY() AS INT);";

        var moduloId =
            await connection.ExecuteScalarAsync<int>(sql, modulo);

        return moduloId;
    }
}
