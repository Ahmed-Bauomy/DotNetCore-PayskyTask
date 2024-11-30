using EmploymentSystem.Application.Contracts;
using EmploymentSystem.Application.Contracts.Adapters;
using EmploymentSystem.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.Vacancy.Queries.GetVacancies
{
    public class GetVacanciesQueryHandler : IRequestHandler<GetVacanciesQuery, List<VacancyDTO>>
    {
        private readonly IVacancyRepositoryAdapter _vacancyRepository;

        public GetVacanciesQueryHandler(IVacancyRepositoryAdapter vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }

        public async Task<List<VacancyDTO>> Handle(GetVacanciesQuery request, CancellationToken cancellationToken)
        {
            var vacancies = await _vacancyRepository.GetAllAsync();
            return vacancies.ToList();
        }
    }
}
