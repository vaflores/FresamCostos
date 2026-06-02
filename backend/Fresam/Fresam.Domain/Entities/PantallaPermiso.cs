using Fresam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Domain.Entities;

public class PantallaPermiso : BaseEntity
{
    public int PantallaPermisoId { get; set; }

    public int PantallaId { get; set; }

    public int PermisoId { get; set; }
}
