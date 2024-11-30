using EmploymentSystem.Application.Contracts.Adapters;
using EmploymentSystem.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.Vacancy.Commands.UpdateVacancy
{
    public class UpdateVacancyCommandHandler : IRequestHandler<UpdateVacancyCommand, bool>
    {
        private readonly IVacancyRepositoryAdapter _vacancyRepository;

        public UpdateVacancyCommandHandler(IVacancyRepositoryAdapter vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }

        public async Task<bool> Handle(UpdateVacancyCommand request, CancellationToken cancellationToken)
        {
            var dbVacancy = await _vacancyRepository.GetByIdAsync(request.Id);
            if (dbVacancy == null) throw new CustomNotFoundException(request.Title,request.Id.ToString());

            await _vacancyRepository.UpdateAsync(request, dbVacancy);
            return true;
        }
    }
}
