using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmploymentSystem.Domain.Entities
{
    public class VacanciesAppliedUsers
    {
        public string ApplicationUserId { get; set; }
        public int VacancyId { get; set; }

        public virtual Vacancy Vacancy { get; set; }
    }
}
