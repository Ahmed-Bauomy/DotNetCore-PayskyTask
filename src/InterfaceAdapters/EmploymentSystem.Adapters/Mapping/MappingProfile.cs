using AutoMapper;
using EmploymentSystem.Application.Features.Vacancy.Commands.CreateVacancy;
using EmploymentSystem.Application.Features.Vacancy.Commands.UpdateVacancy;
using EmploymentSystem.Application.Models;
using EmploymentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Adapters.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateVacancyCommand, Vacancy>().PreserveReferences();
            CreateMap<UpdateVacancyCommand, Vacancy>().ReverseMap().PreserveReferences();
            CreateMap<Vacancy, VacancyDTO>().PreserveReferences();
        }
    }
}
