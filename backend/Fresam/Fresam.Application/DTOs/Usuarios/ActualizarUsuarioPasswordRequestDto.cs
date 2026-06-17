using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.DTOs.Usuarios;

public class ActualizarUsuarioPasswordRequestDto
{
    public int UsuarioId { get; set; }
    public string Password { get; set; } = string.Empty;

}
