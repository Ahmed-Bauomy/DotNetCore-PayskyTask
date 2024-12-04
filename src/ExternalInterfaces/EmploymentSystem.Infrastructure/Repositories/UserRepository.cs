using AutoMapper;
using EmploymentSystem.Application.Contracts;
using EmploymentSystem.Application.Models;
using EmploymentSystem.Infrastructure.Contracts;
using EmploymentSystem.Infrastructure.Data;
using EmploymentSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        private readonly IMapper _mapper;
        public UserRepository(ApplicationDbContext dbContext,IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<UserDTO> GetUserByIdAsync(string id)
        {
            var user = await GetByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<IReadOnlyList<UserDTO>> GetUsersAsync()
        {
            var users = await GetAllAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<IReadOnlyList<UserDTO>> GetUsersAsync(List<string> Ids)
        {
            var users = await _dbSet.Where(u => Ids.Contains(u.Id)).ToListAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }
    }
}
