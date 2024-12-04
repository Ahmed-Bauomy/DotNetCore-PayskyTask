using EmploymentSystem.Domain.Contracts;
using EmploymentSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Infrastructure.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public virtual ICollection<Vacancy> CreatedVacancies { get; set; }
        public virtual ICollection<VacanciesAppliedUsers> AppliedVacancies { get; set; }

    }
}
