using EmploymentSystem.Domain.Common;
using EmploymentSystem.Domain.Entities;
using EmploymentSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            Database.Migrate();
        }
        public virtual DbSet<VacancyModel> Vacancies { get; set; }
        public virtual DbSet<VacanciesAppliedUsers> VacanciesAppliedUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<VacanciesAppliedUsers>()
                .HasKey(t => new { t.UserId, t.VacancyId });


            builder.Entity<VacanciesAppliedUsers>()
                   .HasOne(t => t.ApplicationUser)
                   .WithMany(t => t.AppliedVacancies)
                   .HasForeignKey(t => t.UserId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<VacanciesAppliedUsers>()
                   .HasOne(t => t.Vacancy)
                   .WithMany(t => t.AppliedUsers)
                   .HasForeignKey(t => t.VacancyId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<VacancyModel>()
                   .HasOne(t => t.Employer)
                   .WithMany(x => x.CreatedVacancies)
                   .HasForeignKey(x => x.EmployerId)
                   .IsRequired(false);

            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        //entry.Entity.CreatedBy = "";
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        //entry.Entity.LastModifiedBy = "";
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
