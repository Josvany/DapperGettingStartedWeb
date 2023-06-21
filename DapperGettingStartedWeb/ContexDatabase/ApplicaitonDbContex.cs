using DapperGettingStartedWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace DapperGettingStartedWeb.ContexDatabase
{
    public class ApplicaitonDbContex : DbContext
    {
        public ApplicaitonDbContex(DbContextOptions<ApplicaitonDbContex> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>().Ignore(t => t.Employees);

            modelBuilder.Entity<Employee>()
                .HasOne(c => c.Company).WithMany(e => e.Employees).HasForeignKey(c => c.CompanyId);
        }
    }
}