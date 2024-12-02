using AutoMapper;
using EmploymentSystem.Application.Contracts.Identity;
using EmploymentSystem.Application.Features.User.Commands.SignInUser;
using EmploymentSystem.Application.Features.User.Commands.SignUpUser;
using EmploymentSystem.Application.Models;
using EmploymentSystem.Infrastructure.Contracts;
using EmploymentSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Infrastructure.Services
{
    // TODO: Implement it in Adapter layer
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public IdentityService(UserManager<ApplicationUser> userManager, 
                               RoleManager<IdentityRole> roleManager, 
                               ITokenService tokenService, 
                               IMapper mapper,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<AuthResult> AddUserToRoleAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return new AuthResult() { Success = false, Errors = new string[] { "User not Found." } };
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null) return new AuthResult() { Success = false, Errors = new string[] { "Role not Found." } };

            var result = await _userManager.AddToRoleAsync(user,roleName);
            return new AuthResult() { Success = result.Succeeded, Errors = result.Errors.Select(r => r.Description) };
        }

        public async Task CreateRolesAsync(IEnumerable<string> roles)
        {
            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public async Task<TokenResult> SignInUserAsync(SignInUserCommand signInUser)
        {
            var user = await _userManager.FindByEmailAsync(signInUser.Email);
            if (user == null) new TokenResult() { Errors = new string[] { "Wrong email." }  };
            var test = await _userManager.CheckPasswordAsync(user, signInUser.Password);
            if (!await _userManager.CheckPasswordAsync(user, signInUser.Password))
            {
                return new TokenResult() { Errors = new string[] { "Wrong password." } };
            }

            await _signInManager.SignInAsync(user,false);
            return await _tokenService.GenerateTokenAsync(user);
        }

        public async Task<AuthResult> SignUpUserAsync(SignUpUserCommand signUpUser)
        {
            var user = await _userManager.FindByEmailAsync(signUpUser.Email);
            if (user != null)
            {
                return new AuthResult { Success = false, Errors = new string[] { "User already exists." } };
            }

            var result = await _userManager.CreateAsync(_mapper.Map<ApplicationUser>(signUpUser),signUpUser.Password);
            var dbUser = await _userManager.FindByEmailAsync(signUpUser.Email);
            return new AuthResult { Id = dbUser.Id , Success = result.Succeeded, Errors = result.Errors.Select(e => e.Description) };
        }
    }
}
