using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Domain.Entities
{
    public class VacanciesUsers
    {
        public string UserId { get; set; }
        public int VacancyId { get; set; }
        public virtual User ApplicationUser { get; set; }
        public virtual Vacancy Vacancy { get; set; }
    }
}
