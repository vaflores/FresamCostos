using Fresam.Infrastructure.Repositories.Base;
using Fresam.Application.DTOs.Seguridad;
using Fresam.Infrastructure.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Fresam.Application.Interfaces.Repositories.Security;

namespace Fresam.Infrastructure.Repositories;

public class PerfilSeguridadUsuarioRepository : BaseRepository, IPerfilSeguridadUsuarioRepository
{
    public PerfilSeguridadUsuarioRepository(DapperContext context) : base(context)
    {
    }

    public async Task<List<PerfilSeguridadUsuarioRowDto>> ObtenerPerfilSeguridadUsuarioAsync(int usuarioId)
    {
        using var connection = Context.CreateConnection();

        var query = @"
			SELECT DISTINCT
					u.UsuarioId,
					u.NombreCompleto AS UsuarioNombre,
					m.ModuloId,
					m.Nombre AS ModuloNombre,
					m.Icono AS ModuloIcono,
					m.Orden AS ModuloOrden,
					p.PantallaId,
					p.Nombre AS PantallaNombre,
					p.Icono AS PantallaIcono,
					p.Orden AS PantallaOrden,
					p.Ruta AS PantallaRuta,
					pe.PermisoId,
					pe.Codigo AS PermisoCodigo
				FROM Usuarios u
					INNER JOIN UsuariosRoles ur ON u.UsuarioId = ur.UsuarioId AND ur.Activo = 1
					INNER JOIN Roles r ON ur.RolId = r.RolId AND r.Activo = 1
					INNER JOIN RolesPantallasPermisos rpp ON r.RolId = rpp.RolId AND rpp.Activo = 1
					INNER JOIN PantallasPermisos pp ON rpp.PantallaPermisoId = pp.PantallaPermisoId AND pp.Activo = 1
					INNER JOIN Pantallas p ON pp.PantallaId = p.PantallaId AND p.Activo = 1
					INNER JOIN Modulos m ON p.ModuloId = m.ModuloId AND m.Activo = 1
					INNER JOIN Permisos pe ON pp.PermisoId = pe.PermisoId AND pe.Activo = 1
				WHERE u.UsuarioId = @UsuarioId AND u.Activo = 1";
        var result = await connection.QueryAsync<PerfilSeguridadUsuarioRowDto>(query, new { UsuarioId = usuarioId });
        return result.ToList();
    }
}
