using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Infrastructure.Models
{
    public class VacanciesAppliedUsers
    {
        public string UserId { get; set; }
        public int VacancyId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual VacancyModel Vacancy { get; set; }
    }
}
