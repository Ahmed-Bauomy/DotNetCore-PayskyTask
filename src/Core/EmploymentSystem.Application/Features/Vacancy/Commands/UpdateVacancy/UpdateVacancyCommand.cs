using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.Vacancy.Commands.UpdateVacancy
{
    public class UpdateVacancyCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string? Title { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int MaxNumberOfAllowedApplications { get; set; }
    }
}
