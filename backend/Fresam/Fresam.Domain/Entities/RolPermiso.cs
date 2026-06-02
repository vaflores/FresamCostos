using Fresam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Domain.Entities;

public class RolPermiso : BaseEntity
{
    public int RolPermisoId { get; set; }

    public int RolId { get; set; }

    public int PermisoId { get; set; }
}