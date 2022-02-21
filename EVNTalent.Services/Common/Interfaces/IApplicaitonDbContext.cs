namespace EVNTalent.Services.Common.Interfaces
{
using EVNTalent.Domain.Entities;
using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public interface IApplicaitonDbContext
    {
        public DbSet<Department>  Departments { get; set; }
        public DbSet<Candidate>  Candidates { get; set; }
        Task<int> SaveChangesAsync(); 
            
    }
}
