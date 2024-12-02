using EmploymentSystem.Application.Features.Vacancy.Commands.ApplyToVacancy;
using EmploymentSystem.Application.Features.Vacancy.Commands.CreateVacancy;
using EmploymentSystem.Application.Features.Vacancy.Commands.UpdateVacancy;
using EmploymentSystem.Application.Models;
using EmploymentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Contracts.Adapters
{
    public interface IVacancyRepositoryAdapter
    {
        Task<IReadOnlyList<VacancyDTO>> GetAllAsync();
        Task<IReadOnlyList<VacancyDTO>> GetAsync(Expression<Func<Vacancy, bool>> predicate);
        Task<IReadOnlyList<VacancyDTO>> GetAsync(Expression<Func<Vacancy, bool>>? predicate = null,
                                        Func<IQueryable<Vacancy>, IOrderedQueryable<Vacancy>>? orderBy = null,
                                        string? includeString = null,
                                        bool disableTracking = true);

        Task<Vacancy> GetByIdAsync(int id);
        Task<Vacancy> AddAsync(CreateVacancyCommand entity);
        Task UpdateAsync(UpdateVacancyCommand entity, Vacancy dbEntity);
        Task DeleteAsync(Vacancy entity);

        Task<bool> ApplyToVacancy(ApplyToVacancyCommand applyToVacancyCommand);
    }
}
