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

public class PantallaRepository : BaseRepository, IPantallaRepository
{
    public PantallaRepository(DapperContext context) : base(context)
    {
    }

    public async Task<List<Pantalla>> ObtenerTodosAsync()
    {
        using var connection = Context.CreateConnection();

        var sql = @"
            SELECT
                PantallaId,
                ModuloId,
                Nombre,
                Descripcion,
                Ruta,
                Icono,
                Orden,
                Activo,
                FechaCreacion,
                UsuarioCreacion,
                FechaModificacion,
                UsuarioModificacion
            FROM Pantallas
            WHERE Activo = 1
            ORDER BY Orden";

        var pantallas = await connection.QueryAsync<Pantalla>(sql);
        
        return pantallas.ToList();
    }

    public async Task<int> CrearAsync(Pantalla pantalla)
    {
        using var connection = Context.CreateConnection();

        var sql = @"
            INSERT INTO Pantallas 
            (
                ModuloId, 
                Nombre, 
                Descripcion, 
                Ruta, 
                Icono, 
                Orden, 
                Activo, 
                FechaCreacion, 
                UsuarioCreacion
            )
            
            VALUES 
            (
                @ModuloId, 
                @Nombre, 
                @Descripcion, 
                @Ruta, 
                @Icono, 
                @Orden, 
                @Activo, 
                @FechaCreacion, 
                @UsuarioCreacion
            );

            
            SELECT CAST(SCOPE_IDENTITY() as int)";

        var pantallaId =  
            await connection.ExecuteScalarAsync<int>(sql, pantalla);

        return pantallaId;
    }
}

