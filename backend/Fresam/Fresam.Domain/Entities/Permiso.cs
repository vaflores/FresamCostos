using Fresam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Domain.Entities;

public class Permiso : BaseEntity
{
    public int PermisoId { get; set; }

    public string Codigo { get; set; } = string.Empty;

    public string Descripcion { get; set; } = string.Empty;

    public bool Activo { get; set; }
}

