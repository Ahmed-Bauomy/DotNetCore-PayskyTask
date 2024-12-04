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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public VacancyRepositoryAdapter(IVacancyRepository vacancyRepository, IUserRepository userRepository, IMapper mapper)
        {
            _vacancyRepository = vacancyRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Vacancy> AddAsync(CreateVacancyCommand entity)
        {
            var vacancy = _mapper.Map<Vacancy>(entity);
            return await _vacancyRepository.AddAsync(vacancy);
        }

        public async Task DeleteAsync(Vacancy entity)
        {
            await _vacancyRepository.DeleteAsync(entity);
        }

        public async Task<IReadOnlyList<VacancyDTO>> GetAllAsync()
        {
            //var vacancies = await _vacancyRepository.GetAsync(null, null, "AppliedUsers");
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

        public async Task<VacancyDTO> GetByIdIncludeUsersAsync(int id)
        {
            var result = await _vacancyRepository.GetAsync(v => v.Id == id,null, "AppliedUsers");
            var vacancy = result.FirstOrDefault();
            var vacancyDTO = _mapper.Map<VacancyDTO>(vacancy);
            var UserCreatedVacancy = await _userRepository.GetUserByIdAsync(vacancy.ApplicationUserId);
            var appliedUsers = await _userRepository.GetUsersAsync(vacancy.AppliedUsers.Select(a => a.ApplicationUserId).ToList());
            vacancyDTO.EmployerName = UserCreatedVacancy.UserName;
            vacancyDTO.AppliedUsers = appliedUsers.ToList();
            return vacancyDTO;
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

        public async Task<bool> ApplyToVacancy(ApplyToVacancyCommand applyToVacancyCommand)
        {
            var entity = _mapper.Map<VacanciesAppliedUsers>(applyToVacancyCommand);
            await _vacancyRepository.ApplyUserToVacancy(entity);
            return true;
        }
    }
}
