using Microsoft.EntityFrameworkCore;
using UniversitySys.Models;

namespace UniversitySys.SystemContext
{
    public class UniversityContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public UniversityContext():base()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-IOVTDI0;Database=ITI_University;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
