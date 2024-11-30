using EmploymentSystem.Application.Contracts.Adapters;
using EmploymentSystem.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.Vacancy.Commands.DeleteVacancy
{
    public class DeleteVacancyCommandHandler : IRequestHandler<DeleteVacancyCommand, bool>
    {
        private readonly IVacancyRepositoryAdapter _repositoryAdapter;

        public DeleteVacancyCommandHandler(IVacancyRepositoryAdapter repositoryAdapter)
        {
            _repositoryAdapter = repositoryAdapter;
        }

        public async Task<bool> Handle(DeleteVacancyCommand request, CancellationToken cancellationToken)
        {
            var dbVacancy = await _repositoryAdapter.GetByIdAsync(request.Id);
            if (dbVacancy == null) throw new CustomNotFoundException("",request.Id.ToString());

            await _repositoryAdapter.DeleteAsync(dbVacancy);
            return true;
        }
    }
}
