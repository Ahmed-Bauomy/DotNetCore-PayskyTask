using EmploymentSystem.Domain.Common;
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
    }
}
