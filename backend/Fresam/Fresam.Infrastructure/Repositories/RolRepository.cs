using Dapper;
using Fresam.Application.Interfaces.Repositories;
using Fresam.Domain.Entities;
using Fresam.Infrastructure.Data;
using Fresam.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Infrastructure.Repositories;

public class RolRepository : BaseRepository, IRolRepository
{
    private readonly DapperContext _context;
    public RolRepository(DapperContext context) : base(context)
    {
        _context = context;
    }
    public async Task<List<Rol>> ObtenerTodosAsync()
    {
        using var connection = Context.CreateConnection();
        var sql = @"
                SELECT 
                    RolId, 
                    Nombre, 
                    Descripcion, 
                    Activo 
                FROM Roles";
        var roles = await connection.QueryAsync<Rol>(sql);
        return roles.ToList();
    }
    
    public async Task<int> CrearAsync(Rol rol)
    {
        using var connection = Context.CreateConnection();

        var sql = @"
            INSERT INTO Roles
            (
                Nombre,
                Descripcion,
                Activo,
                FechaCreacion,
                UsuarioCreacion
            )
            VALUES
            (
                @Nombre,
                @Descripcion,
                @Activo,
                @FechaCreacion,
                @UsuarioCreacion
            );

            SELECT CAST(SCOPE_IDENTITY() AS INT);";

        var rolId =
            await connection.ExecuteScalarAsync<int>(sql, rol);

        return rolId;
    }
}