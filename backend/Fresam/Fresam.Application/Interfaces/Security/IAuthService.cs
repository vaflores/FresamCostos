using Fresam.Application.DTOs.Auth;
using Fresam.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresam.Application.Interfaces.Security;

public interface IAuthService
{    
    Task<LoginResponseDto> LoginAsync(LoginRequestDto dto);
}
