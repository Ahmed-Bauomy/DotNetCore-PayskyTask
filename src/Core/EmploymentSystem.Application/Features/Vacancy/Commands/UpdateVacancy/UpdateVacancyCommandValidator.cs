using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.Vacancy.Commands.UpdateVacancy
{
    public class UpdateVacancyCommandValidator : AbstractValidator<UpdateVacancyCommand>
    {
        public UpdateVacancyCommandValidator()
        {
            RuleFor(t => t.Id)
                .NotEmpty().WithMessage("{Id} is Required.");
            RuleFor(t => t.Title)
                .NotEmpty().WithMessage("{Title} is Required.");
            RuleFor(t => t.Description)
                .NotEmpty().WithMessage("{Description} is Required.");
            RuleFor(t => t.ExpiryDate)
                .NotNull().WithMessage("{ExpiryDate} is Required.");
            RuleFor(t => t.MaxNumberOfAllowedApplications)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("{MaxNumberOfAllowedApplications} must be greater than Zero");
        }
    }
}
