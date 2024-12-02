using EmploymentSystem.Application.Contracts.Identity;
using EmploymentSystem.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.User.Commands.SignInUser
{
    public class SignInUserCommandHandler : IRequestHandler<SignInUserCommand, TokenResult>
    {
        private readonly IIdentityService _identityService;

        public SignInUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<TokenResult> Handle(SignInUserCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.SignInUserAsync(request);
        }
    }
}
