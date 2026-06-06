using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.DTOs.Modulos;

public class ModuloDto
{
    public int ModuloId { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string? Descripcion { get; set; }

    public string? Icono { get; set; }

    public int Orden { get; set; }

    public bool Activo { get; set; }
}
