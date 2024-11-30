using EmploymentSystem.Domain.Common;
using EmploymentSystem.Domain.Contracts;
using EmploymentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Contracts
{
    public interface IVacancyRepository : IAsyncRepository<Vacancy>
    {
        Task<bool> ApplyToVacancy(int vacancyId, string userId);
    }
}
