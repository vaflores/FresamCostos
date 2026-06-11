using Fresam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Domain.Entities;

public class RolPantallaPermiso : BaseEntity
{
    public int RolPantallaPermisoId {  get; set; }
    public int RolId { get; set; }
    public int PantallaPermisoId { get; set; }
    public bool Activo {  get; set; }
}
