using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fresam.Application.DTOs.Seguridad;
using System.Security.Cryptography.X509Certificates;
using Fresam.Application.Interfaces.Repositories.Security;
using Fresam.Application.Interfaces.Security;

namespace Fresam.Application.Services.Security;

public class PerfilSeguridadUsuarioService : IPerfilSeguridadUsuarioService
{
    private readonly IPerfilSeguridadUsuarioRepository _perfilSeguridadUsuarioRepository;

    public PerfilSeguridadUsuarioService(IPerfilSeguridadUsuarioRepository perfilSeguridadUsuarioRepository)
    {
        _perfilSeguridadUsuarioRepository = perfilSeguridadUsuarioRepository;
    }

    public async Task<PerfilSeguridadUsuarioDto> ObtenerPerfilSeguridadUsuarioAsync(int usuarioId)
    {
        var resultado = await _perfilSeguridadUsuarioRepository.ObtenerPerfilSeguridadUsuarioAsync(usuarioId);

        PerfilSeguridadUsuarioDto perfilUsuario = new PerfilSeguridadUsuarioDto { UsuarioId = usuarioId };

        if (resultado.Count > 0)
        {
            var usuario = resultado.First();

            perfilUsuario.UsuarioId = usuario.UsuarioId;
            perfilUsuario.UsuarioNombre = usuario.UsuarioNombre;

            perfilUsuario.Modulos = resultado
                .GroupBy(x => x.ModuloId)
                .Select(g =>
                {
                    var modulo = g.First();

                    return new SeguridadModuloDto
                    {
                        ModuloId = modulo.ModuloId,
                        Nombre = modulo.ModuloNombre,
                        Orden = modulo.ModuloOrden,
                        Icono = modulo.ModuloIcono
                    };
                })
                .ToList();

            foreach (SeguridadModuloDto modulo in perfilUsuario.Modulos)
            {
                modulo.Pantallas = resultado
                    .Where(m => m.ModuloId == modulo.ModuloId)
                    .GroupBy(x => x.PantallaId)
                    .Select(g =>
                    {
                        var pantalla = g.First();

                        return new SeguridadPantallaDto
                        {
                            PantallaId = pantalla.PantallaId,
                            Nombre = pantalla.PantallaNombre,
                            Orden = pantalla.PantallaOrden,
                            Icono = pantalla.PantallaIcono,
                            Ruta = pantalla.PantallaRuta
                        };
                    })
                    .ToList();

                foreach (SeguridadPantallaDto pantalla in modulo.Pantallas)
                {
                    pantalla.Permisos = resultado
                        .Where(p => p.PantallaId == pantalla.PantallaId)
                        .Select(x => new SeguridadPermisoDto
                        {
                            PermisoId = x.PermisoId,
                            Codigo = x.PermisoCodigo
                        })
                        .ToList();
                }
            }
        }

        return perfilUsuario;
    }
}
