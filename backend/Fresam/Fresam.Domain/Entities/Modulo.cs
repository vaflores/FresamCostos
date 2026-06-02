using Fresam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Domain.Entities;

public class Modulo : BaseEntity
{
    public int ModuloId { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string? Icono { get; set; }

    public int Orden { get; set; }

    public bool Activo { get; set; }
}
