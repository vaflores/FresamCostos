using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.DTOs.UsuarioRol;

public class UsuarioRolDto
{
    public int UsuarioRolId { get; set; }
    public int UsuarioId { get; set; }
    public int RolId { get; set; }
    public bool Activo { get; set; }
}
