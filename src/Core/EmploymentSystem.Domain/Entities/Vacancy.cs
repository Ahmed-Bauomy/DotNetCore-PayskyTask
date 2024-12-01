using EmploymentSystem.Domain.Common;
using EmploymentSystem.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Domain.Entities
{
    public class Vacancy : EntityBase
    {
        public DateTime ExpiryDate { get; set; }
        public string? Title { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int MaxNumberOfAllowedApplications { get; set; }
        public string? EmployerId { get; set; }

        public virtual User Employer { get; set; }
        public virtual ICollection<VacanciesUsers> AppliedUsers { get; set; }
    }
}
