using EmploymentSystem.Application.Contracts.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Infrastructure.Data
{
    public class SeedData
    {
        private readonly IConfiguration _configuration;
        private readonly IIdentityService _identityService;

        public SeedData(IConfiguration configuration, IIdentityService identityService)
        {
            _configuration = configuration;
            _identityService = identityService;
        }

        public async Task SetUpRoles()
        {
            var roles = _configuration.GetSection("Roles").Get<IEnumerable<string>>();
            await _identityService.CreateRolesAsync(roles);
        }
    }
}
