using EVNTalent.Domain.Entities;
using EVNTalent.Services.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVNTalent.Services.Common.Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicaitonDbContext
    {
        public ApplicationDbContext( DbContextOptions options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Candidate> Candidates { get; set; }

        public Task<int> SaveChangesAsync()
        {
            var selectedEntityList = ChangeTracker.Entries()
                    .Where(x => x.Entity is BaseEntity &&
                     (x.State == EntityState.Added || x.State == EntityState.Modified));



            foreach (var entity in selectedEntityList)
            {
                ((BaseEntity)entity.Entity).ModifiedDate = DateTime.Now;
            }

            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
