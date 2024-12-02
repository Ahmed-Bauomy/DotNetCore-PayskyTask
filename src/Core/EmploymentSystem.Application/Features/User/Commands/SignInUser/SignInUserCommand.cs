using EmploymentSystem.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.User.Commands.SignInUser
{
    public class SignInUserCommand : IRequest<TokenResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
