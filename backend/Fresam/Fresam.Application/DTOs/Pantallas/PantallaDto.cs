using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.DTOs.Pantallas;

public class PantallaDto
{
    public int PantallaId { get; set; }
    public int ModuloId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Ruta { get; set; } = string.Empty;    
    public string? Descripcion { get; set; } = string.Empty;
    public string? Icono { get; set; } = string.Empty;
    public int Orden { get; set; }
    public bool Activo { get; set; }
}

