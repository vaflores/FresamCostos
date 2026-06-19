using Fresam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.Interfaces.Security;

public interface IJwtService
{
    string GenerarToken(Usuario usuario, List<string> permisos);
}
