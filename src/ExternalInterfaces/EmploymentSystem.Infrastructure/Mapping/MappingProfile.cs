using AutoMapper;
using EmploymentSystem.Application.Features.User.Commands.SignInUser;
using EmploymentSystem.Application.Features.User.Commands.SignUpUser;
using EmploymentSystem.Application.Features.Vacancy.Commands.ApplyToVacancy;
using EmploymentSystem.Application.Models;
using EmploymentSystem.Domain.Entities;
using EmploymentSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDTO, ApplicationUser>().ReverseMap().PreserveReferences();
            CreateMap<SignUpUserCommand, ApplicationUser>().ReverseMap().PreserveReferences();
            CreateMap<ApplyToVacancyCommand, VacanciesAppliedUsers>().ReverseMap().PreserveReferences();
        }
    }
}
