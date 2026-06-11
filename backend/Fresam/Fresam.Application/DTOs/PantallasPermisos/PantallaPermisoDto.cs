using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.DTOs.PantallasPermisos;

public class PantallaPermisoDto
{
    public int PantallaPermisoId { get; set; }
    public int PantallaId { get; set; }
    public int PermisoId { get; set; }
    public bool Activo { get; set; }
}

