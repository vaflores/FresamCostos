using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.DTOs.Seguridad;

public class PerfilSeguridadUsuarioDto
{
    public int UsuarioId { get; set; }
    public string UsuarioNombre { get; set; } = string.Empty;
    public List<SeguridadModuloDto> Modulos { get; set; } = new List<SeguridadModuloDto>();
}
