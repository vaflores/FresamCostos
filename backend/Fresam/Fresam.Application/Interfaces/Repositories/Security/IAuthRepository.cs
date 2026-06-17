using Fresam.Application.DTOs.Auth;
using Fresam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.Interfaces.Repositories.Security;

public interface IAuthRepository
{
    Task<Usuario?> ObtenerPorNombreUsuarioAsync(string usuarioNombre);
}
