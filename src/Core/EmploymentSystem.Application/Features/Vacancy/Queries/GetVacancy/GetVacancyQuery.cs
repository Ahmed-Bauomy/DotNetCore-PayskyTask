using EmploymentSystem.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.Vacancy.Queries.GetVacancy
{
    public class GetVacancyQuery : IRequest<VacancyDTO>
    {
        public GetVacancyQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }  
    }
}
