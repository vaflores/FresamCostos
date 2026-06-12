using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.DTOs.Seguridad;

public class PerfilSeguridadUsuarioRowDto
{
    public int UsuarioId { get; set; }
    public string UsuarioNombre { get; set; } = string.Empty;
    public int ModuloId { get; set; }
    public string ModuloNombre { get; set; } = string.Empty;
    public int ModuloOrden { get; set; }
    public string ModuloIcono { get; set; } = string.Empty;
    public int PantallaId { get; set; }     
    public string PantallaNombre { get; set; } = string.Empty;
    public int PantallaOrden { get; set; }  
    public string PantallaIcono { get; set; } = string.Empty;
    public string PantallaRuta { get; set; } = string.Empty;
    public int PermisoId { get; set; }
    public string PermisoCodigo { get; set; } = string.Empty;
}
