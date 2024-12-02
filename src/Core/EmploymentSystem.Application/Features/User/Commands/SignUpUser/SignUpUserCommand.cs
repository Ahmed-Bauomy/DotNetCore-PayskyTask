using EmploymentSystem.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.User.Commands.SignUpUser
{
    public class SignUpUserCommand : IRequest<AuthResult>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsEmployerUser { get; set; }
    }
}
