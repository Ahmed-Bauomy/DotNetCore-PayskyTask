using EmploymentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Infrastructure.Models
{
    public class VacancyModel : Vacancy
    {
        public virtual ApplicationUser Employer { get; set; }
        public virtual ICollection<VacanciesAppliedUsers> AppliedUsers { get; set; }
    }
}
