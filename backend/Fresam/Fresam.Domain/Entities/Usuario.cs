using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fresam.Domain.Common;

namespace Fresam.Domain.Entities;

public class Usuario : BaseEntity
{
    public int UsuarioId { get; set; }

    public int? EmpleadoId { get; set; }

    public string NombreUsuario { get; set; } = string.Empty;

    public string NombreCompleto { get; set; } = string.Empty;

    public string Correo { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public bool Activo { get; set; }
}
