using EmploymentSystem.Application;
using EmploymentSystem.Infrastructure;
using EmploymentSystem.Adapters;
using EmploymentSystem.Infrastructure.Data;

namespace EmploymentSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddAdpatersServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            // seed data
            var seed = app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedData>();
            seed.SetUpRoles();

            app.Run();
        }
    }
}
