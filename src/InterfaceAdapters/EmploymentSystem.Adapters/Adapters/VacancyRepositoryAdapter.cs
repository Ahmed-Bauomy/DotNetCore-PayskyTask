using AutoMapper;
using EmploymentSystem.Application.Contracts;
using EmploymentSystem.Application.Contracts.Adapters;
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

namespace EmploymentSystem.Adapters.Adapters
{
    public class VacancyRepositoryAdapter : IVacancyRepositoryAdapter
    {
        private readonly IVacancyRepository _vacancyRepository;
        private readonly IMapper _mapper;

        public VacancyRepositoryAdapter(IVacancyRepository vacancyRepository, IMapper mapper)
        {
            _vacancyRepository = vacancyRepository;
            _mapper = mapper;
        }

        public async Task<Vacancy> AddAsync(CreateVacancyCommand entity)
        {
            var vacancy = _mapper.Map<Vacancy>(entity);
            return await _vacancyRepository.AddAsync(vacancy);
        }

        public async Task<bool> ApplyToVacancy(ApplyToVacancyCommand applyToVacancyCommand)
        {
            var entity = _mapper.Map<VacanciesUsers>(applyToVacancyCommand);
            await _vacancyRepository.ApplyUserToVacancy(entity);
            return true;
        }

        public async Task DeleteAsync(Vacancy entity)
        {
            await _vacancyRepository.DeleteAsync(entity);
        }

        public async Task<IReadOnlyList<VacancyDTO>> GetAllAsync()
        {
            var vacancies = await _vacancyRepository.GetAllAsync();
            return _mapper.Map<List<VacancyDTO>>(vacancies);
        }

        public async Task<IReadOnlyList<VacancyDTO>> GetAsync(Expression<Func<Vacancy, bool>> predicate)
        {
            var vacancies = await _vacancyRepository.GetAsync(predicate);
            return _mapper.Map<List<VacancyDTO>>(vacancies);
        }

        public async Task<IReadOnlyList<VacancyDTO>> GetAsync(Expression<Func<Vacancy, bool>>? predicate = null, Func<IQueryable<Vacancy>, IOrderedQueryable<Vacancy>>? orderBy = null, string? includeString = null, bool disableTracking = true)
        {
            var vacancies = await _vacancyRepository.GetAsync(predicate,orderBy,includeString,disableTracking);
            return _mapper.Map<List<VacancyDTO>>(vacancies);
        }

        public async Task<Vacancy> GetByIdAsync(int id)
        {
            return await _vacancyRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(UpdateVacancyCommand entity, Vacancy dbEntity)
        {
            _mapper.Map(entity,dbEntity, typeof(UpdateVacancyCommand), typeof(Vacancy));
            await _vacancyRepository.UpdateAsync(dbEntity);
        }
    }
}
