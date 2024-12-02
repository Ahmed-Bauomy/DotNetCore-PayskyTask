using EmploymentSystem.Application.Models;
using EmploymentSystem.Domain.Entities;
using EmploymentSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Infrastructure.Contracts
{
    public interface ITokenService
    {
        Task<TokenResult> GenerateTokenAsync(ApplicationUser user);
        Task<ClaimsPrincipal> CreateClaimsPrincipal(ApplicationUser user);
    }
}
