using EmploymentSystem.Adapters.Adapters;
using EmploymentSystem.Application.Contracts.Adapters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Adapters
{
    public static class AdapterLayerRegistration
    {
        public static IServiceCollection AddAdpatersServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IVacancyRepositoryAdapter, VacancyRepositoryAdapter>();
            return services;
        }
    }
}
