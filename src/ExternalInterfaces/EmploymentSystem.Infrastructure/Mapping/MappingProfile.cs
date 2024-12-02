using AutoMapper;
using EmploymentSystem.Application.Features.User.Commands.SignInUser;
using EmploymentSystem.Application.Features.User.Commands.SignUpUser;
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
            CreateMap<Vacancy, VacancyModel>().ReverseMap();
            CreateMap<User, ApplicationUser>().ReverseMap();
            CreateMap<VacanciesUsers, VacanciesAppliedUsers>().ReverseMap();
            CreateMap<SignUpUserCommand, ApplicationUser>().ReverseMap();
        }
    }
}
