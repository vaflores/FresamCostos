using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.DTOs.Seguridad;

public class SeguridadPantallaDto
{
    public int PantallaId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Orden { get; set; }
    public string Icono { get; set; } = string.Empty;
    public string Ruta { get; set; } = string.Empty;
    public List<SeguridadPermisoDto> Permisos { get; set; } = new List<SeguridadPermisoDto>();
}
