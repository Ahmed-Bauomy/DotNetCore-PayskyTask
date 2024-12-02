using AutoMapper;
using EmploymentSystem.Application.Contracts;
using EmploymentSystem.Domain.Entities;
using EmploymentSystem.Infrastructure.Data;
using EmploymentSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Infrastructure.Repositories
{
    public class VacancyRepository : IVacancyRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<VacancyModel> _dbSet;
        private readonly IMapper _mapper;
        public VacancyRepository(ApplicationDbContext dbContext,IMapper mapper)
        {
            _context = dbContext;
            _dbSet = _context.Set<VacancyModel>();
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<Vacancy>> GetAllAsync()
        {
            return _mapper.Map<List<Vacancy>>(await _dbSet.Include(v => v.AppliedUsers).Include(v => v.Employer).ToListAsync());
        }

        public async Task<IReadOnlyList<Vacancy>> GetAsync(Expression<Func<Vacancy, bool>> predicate)
        {
            return _mapper.Map<List<Vacancy>>( await _dbSet.Where(predicate).ToListAsync());
        }

        public async Task<IReadOnlyList<Vacancy>> GetAsync(Expression<Func<Vacancy, bool>>? predicate = null, Func<IQueryable<Vacancy>, IOrderedQueryable<Vacancy>>? orderBy = null, string? includeString = null, bool disableTracking = true)
        {
            var query = _dbSet.AsQueryable();
            if (!string.IsNullOrEmpty(includeString)) query = query.Include(includeString);
            if (predicate != null)
            {
                query = _mapper.Map<IQueryable<VacancyModel>>(query.Where(predicate));
            }
            if (disableTracking) query = query.AsNoTracking();
            if (orderBy != null) return await orderBy(_mapper.Map<IQueryable<Vacancy>>(query)).ToListAsync();

            return _mapper.Map<List<Vacancy>>(await query.ToListAsync());
        }

        public async Task<Vacancy> GetByIdAsync(int id)
        {
            return _mapper.Map<Vacancy>(await _dbSet.Where(v => v.Id == id).AsNoTracking().FirstOrDefaultAsync());
        }

        public async Task<Vacancy> AddAsync(Vacancy entity)
        {
            var vacancyModel = _mapper.Map<VacancyModel>(entity);
            var result = await _dbSet.AddAsync(vacancyModel);
            await _context.SaveChangesAsync();
            return _mapper.Map <Vacancy>(result.Entity);
        }

        public async Task UpdateAsync(Vacancy entity)
        {
            //_dbSet.Update(entity);
            var vacancyModel = _mapper.Map<VacancyModel>(entity);
            _context.Attach(vacancyModel);
            _context.Entry(vacancyModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Vacancy entity)
        {
            var vacancyModel = _mapper.Map<VacancyModel>(entity);
            _dbSet.Remove(vacancyModel);
            await _context.SaveChangesAsync();
        }

        public async Task<VacanciesUsers> ApplyUserToVacancy(VacanciesUsers entity)
        {
            var model = _mapper.Map<VacanciesAppliedUsers>(entity);
            var vacancy = _dbSet.Include(t => t.AppliedUsers).FirstOrDefault(t => t.Id == model.VacancyId);
            if (vacancy != null)
            {
                vacancy.AppliedUsers.Add(model);
                await _context.SaveChangesAsync();
            }
            return entity;
        }
    }
}
