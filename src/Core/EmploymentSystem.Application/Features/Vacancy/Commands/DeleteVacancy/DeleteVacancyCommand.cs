using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Features.Vacancy.Commands.DeleteVacancy
{
    public class DeleteVacancyCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteVacancyCommand(int id)
        {
            Id = id;
        }
    }
}
