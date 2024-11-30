using EmploymentSystem.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.Vacancy.Queries.GetVacancies
{
    public class GetVacanciesQuery : IRequest<List<VacancyDTO>>
    {
    }
}
