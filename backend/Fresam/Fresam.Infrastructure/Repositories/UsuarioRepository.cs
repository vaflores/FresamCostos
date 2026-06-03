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
                    NombreUsuario, 
                    NombreCompleto, 
                    Correo, 
                    Activo 
                FROM Usuarios";

        var usuarios = await connection.QueryAsync<Usuario>(sql);

        return usuarios.ToList();
    }
}
