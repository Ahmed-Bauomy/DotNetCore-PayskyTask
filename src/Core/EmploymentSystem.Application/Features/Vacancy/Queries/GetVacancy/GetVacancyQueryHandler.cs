using EmploymentSystem.Application.Contracts.Adapters;
using EmploymentSystem.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.Vacancy.Queries.GetVacancy
{
    public class GetVacancyQueryHandler : IRequestHandler<GetVacancyQuery, VacancyDTO>
    {
        private readonly IVacancyRepositoryAdapter _vacancyRepositoryAdapter;

        public GetVacancyQueryHandler(IVacancyRepositoryAdapter vacancyRepositoryAdapter)
        {
            _vacancyRepositoryAdapter = vacancyRepositoryAdapter;
        }

        public async Task<VacancyDTO> Handle(GetVacancyQuery request, CancellationToken cancellationToken)
        {
            return await _vacancyRepositoryAdapter.GetByIdIncludeUsersAsync(request.Id);
        }
    }
}
