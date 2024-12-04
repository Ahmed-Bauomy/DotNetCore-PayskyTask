using EmploymentSystem.Domain.Contracts;
using EmploymentSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Infrastructure.Contracts
{
    public interface IApplicationUserRepository : IAsyncRepository<ApplicationUser>
    {
    }
}
