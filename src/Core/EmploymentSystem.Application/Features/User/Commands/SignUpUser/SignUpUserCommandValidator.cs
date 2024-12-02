using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.User.Commands.SignUpUser
{
    public class SignUpUserCommandValidator : AbstractValidator<SignUpUserCommand>
    {
        public SignUpUserCommandValidator()
        {
            RuleFor(t => t.Email)
                .NotEmpty().WithMessage("{Email} is required.")
                .EmailAddress().WithMessage("{Email} format not valid.");

            RuleFor(p => p.Password).NotEmpty().WithMessage("{password} is required.")
                    .MinimumLength(8).WithMessage("password length must be at least 8.")
                    .MaximumLength(16).WithMessage("password length must not exceed 16.")
                    .Matches(@"[A-Z]+").WithMessage("password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("password must contain at least one number.");
            RuleFor(t => t.FirstName)
                .NotEmpty().WithMessage("{FirstName} is required.");
            RuleFor(t => t.LastName)
                .NotEmpty().WithMessage("{LastName} is required.");
            RuleFor(t => t.CompanyName)
                .NotEmpty().WithMessage("{CompanyName} is required.");
            RuleFor(t => t.PhoneNumber)
                .NotEmpty().WithMessage("{PhoneNumber} is required.");
        }
    }
}
