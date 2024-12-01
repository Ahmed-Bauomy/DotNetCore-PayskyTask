using EmploymentSystem.Application.Contracts;
using EmploymentSystem.Infrastructure.Data;
using EmploymentSystem.Infrastructure.Models;
using EmploymentSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Infrastructure
{
    public static class InfrastructureLayerRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            // Configure SqlServer
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            // Configure Identity
            services.AddIdentity<ApplicationUser,IdentityRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = true;
                o.Password.RequireUppercase = true;
                o.Password.RequireNonAlphanumeric = true;
                o.Password.RequiredLength = 6;
                o.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>();
            //services.AddIdentityCore<ApplicationUser>(o =>
            //{
            //    o.Password.RequireDigit = true;
            //    o.Password.RequireLowercase = true;
            //    o.Password.RequireUppercase = true;
            //    o.Password.RequireNonAlphanumeric = true;
            //    o.Password.RequiredLength = 6;
            //    o.User.RequireUniqueEmail = true;
            //}).AddEntityFrameworkStores<ApplicationDbContext>()
            //  .AddRoles<IdentityRole>()
            //  .AddDefaultTokenProviders();

            // Configure JWT


            // Configure Services
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IVacancyRepository, VacancyRepository>();
            services.AddScoped<SeedData>();
            return services;
        }
    }
}
