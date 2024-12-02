using EmploymentSystem.Application.Contracts.Identity;
using EmploymentSystem.Application.Models;
using EmploymentSystem.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.User.Commands.SignUpUser
{
    public class SignUpUserCommandHandler : IRequestHandler<SignUpUserCommand, AuthResult>
    {
        private readonly IIdentityService _identityService;

        public SignUpUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<AuthResult> Handle(SignUpUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.SignUpUserAsync(request);
            if (!result.Success) return result;

            if(request.IsEmployerUser)
            {
                await _identityService.AddUserToRoleAsync(result.Id,Roles.Employer.ToString());
            }
            else
            {
                await _identityService.AddUserToRoleAsync(result.Id, Roles.Applicant.ToString());
            }
            return result;
        }
    }
}
