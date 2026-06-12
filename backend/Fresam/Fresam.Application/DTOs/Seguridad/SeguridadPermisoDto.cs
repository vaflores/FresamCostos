using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.DTOs.Seguridad;

public class SeguridadPermisoDto
{
    public int PermisoId { get; set; }
    public string Codigo { get; set; } = string.Empty;
}
