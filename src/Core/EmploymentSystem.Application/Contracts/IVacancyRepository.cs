using EmploymentSystem.Application.Features.Vacancy.Commands.CreateVacancy;
using EmploymentSystem.Application.Features.Vacancy.Commands.UpdateVacancy;
using EmploymentSystem.Application.Models;
using EmploymentSystem.Domain.Common;
using EmploymentSystem.Domain.Contracts;
using EmploymentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Contracts
{
    public interface IVacancyRepository : IAsyncRepository<Vacancy>
    {
        Task<IReadOnlyList<Vacancy>> GetAllIncludingUsersAsync();
        Task<bool> ApplyUserToVacancy(VacanciesAppliedUsers entity);
    }
}
