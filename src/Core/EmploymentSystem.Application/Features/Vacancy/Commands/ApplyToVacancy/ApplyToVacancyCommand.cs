using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.Vacancy.Commands.ApplyToVacancy
{
    public class ApplyToVacancyCommand : IRequest<bool>
    {
        public int VacancyId { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
