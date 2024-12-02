using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.User.Commands.SignInUser
{
    public class SignInUserCommandValidator : AbstractValidator<SignInUserCommand>
    {
        public SignInUserCommandValidator()
        {
            RuleFor(t => t.Email)
                .NotEmpty().WithMessage("{Email} is required.");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{password} is required.");
        }
    }
}
