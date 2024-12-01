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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public SeedData(RoleManager<IdentityRole> roleManager,IConfiguration configuration)
        {
            _roleManager = roleManager;
            _configuration = configuration;
        }


        public async Task SetUpRoles()
        {
            var roles = _configuration.GetSection("Roles").Get<IEnumerable<string>>();
            foreach (var role in roles) 
            { 
                if(!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
