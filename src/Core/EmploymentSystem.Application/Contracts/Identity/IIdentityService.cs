using EmploymentSystem.Application.Features.User.Commands.SignInUser;
using EmploymentSystem.Application.Features.User.Commands.SignUpUser;
using EmploymentSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Contracts.Identity
{
    public interface IIdentityService
    {
        Task<TokenResult> SignInUserAsync(SignInUserCommand signInUser);
        Task<AuthResult> SignUpUserAsync(SignUpUserCommand user);
        Task<AuthResult> AddUserToRoleAsync(string userId, string roleName);
        Task CreateRolesAsync(IEnumerable<string> roles);
    }
}
