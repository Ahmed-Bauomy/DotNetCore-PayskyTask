using EmploymentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Models
{
    public class VacancyDTO
    {
        public int Id { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string? Title { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int MaxNumberOfAllowedApplications { get; set; }
        public virtual User Employer { get; set; }
        public virtual ICollection<VacanciesUsers> AppliedUsers { get; set; }
    }
}
