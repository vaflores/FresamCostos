using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.DTOs.Permisos;

public class CrearPermisoDto
{
    public string Codigo { get; set; } = string.Empty;

    public string? Descripcion { get; set; }
}