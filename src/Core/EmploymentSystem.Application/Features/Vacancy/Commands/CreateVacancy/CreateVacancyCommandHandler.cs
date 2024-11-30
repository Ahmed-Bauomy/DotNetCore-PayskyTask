using EmploymentSystem.Application.Contracts.Adapters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.Vacancy.Commands.CreateVacancy
{
    public class CreateVacancyCommandHandler : IRequestHandler<CreateVacancyCommand, int>
    {
        private readonly IVacancyRepositoryAdapter _vacancyRepository;

        public CreateVacancyCommandHandler(IVacancyRepositoryAdapter vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }

        public async Task<int> Handle(CreateVacancyCommand request, CancellationToken cancellationToken)
        {
            var createdVacancy = await _vacancyRepository.AddAsync(request);
            return createdVacancy.Id;
        }
    }
}
