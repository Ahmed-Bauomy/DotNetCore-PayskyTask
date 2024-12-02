using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmploymentSystem.Domain.Entities
{
    public class VacanciesUsers
    {
        public string UserId { get; set; }
        public int VacancyId { get; set; }

        public string UserName { get; set; }
        [JsonIgnore]
        public virtual User ApplicationUser { get; set; }
        [JsonIgnore]
        public virtual Vacancy Vacancy { get; set; }
    }
}
