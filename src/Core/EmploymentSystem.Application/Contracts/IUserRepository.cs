using EmploymentSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Contracts
{
    public interface IUserRepository
    {
        Task<IReadOnlyList<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserByIdAsync(string id);
        Task<IReadOnlyList<UserDTO>> GetUsersAsync(List<string> Ids);
    }
}
