using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace Projekt_WPF_EF_PraktykiStudenckie.Model
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<SupervisorUniversity> UniversitySupervisors { get; set; }
        public DbSet<SupervisorCompany> CompanySupervisors { get; set; }
        public DbSet<Internship> Internships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LenovoE14-MZ;Initial Catalog=EF-Internships;Integrated Security=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Internship>()
                .HasOne(e => e.Company)
                .WithMany(e => e.Internships)
                .HasForeignKey(e => e.CompanyId)
                .HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<Internship>()
                .HasOne(e => e.Student)
                .WithOne(e => e.Internship);*/

        }
    }
}