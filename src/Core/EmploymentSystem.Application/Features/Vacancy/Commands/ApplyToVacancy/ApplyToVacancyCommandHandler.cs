using EmploymentSystem.Application.Contracts.Adapters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.Vacancy.Commands.ApplyToVacancy
{
    public class ApplyToVacancyCommandHandler : IRequestHandler<ApplyToVacancyCommand, bool>
    {
        private readonly IVacancyRepositoryAdapter _vacancyRepository;

        public ApplyToVacancyCommandHandler(IVacancyRepositoryAdapter vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }

        public async Task<bool> Handle(ApplyToVacancyCommand request, CancellationToken cancellationToken)
        {
            return await _vacancyRepository.ApplyToVacancy(request);
        }
    }
}
