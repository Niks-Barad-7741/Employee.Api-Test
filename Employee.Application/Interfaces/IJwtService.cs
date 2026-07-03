using Employee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(Employe employe, List<string> roles);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetClaimsPrincipalFromExpiredToken(string? token);
    }
}