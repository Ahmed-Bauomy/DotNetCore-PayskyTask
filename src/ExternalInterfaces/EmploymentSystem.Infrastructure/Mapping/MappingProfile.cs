using AutoMapper;
using EmploymentSystem.Application.Features.User.Commands.SignInUser;
using EmploymentSystem.Application.Features.User.Commands.SignUpUser;
using EmploymentSystem.Application.Features.Vacancy.Commands.ApplyToVacancy;
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
            CreateMap<Vacancy, VacancyModel>().ReverseMap().PreserveReferences();
            CreateMap<User, ApplicationUser>().ReverseMap().PreserveReferences();
            CreateMap<VacanciesUsers, VacanciesAppliedUsers>().ReverseMap().PreserveReferences()
                .ForMember(v => v.UserName,opt => opt.MapFrom(t => t.ApplicationUser.UserName));
            CreateMap<SignUpUserCommand, ApplicationUser>().ReverseMap().PreserveReferences();
            CreateMap<ApplyToVacancyCommand, VacanciesUsers>().ReverseMap().PreserveReferences();
        }
    }
}
