using Microsoft.EntityFrameworkCore;
using Shortlist.Api.Models;

namespace Shortlist.Api.Data
{
    public class OrganizationContext : DbContext
    {
        public OrganizationContext(DbContextOptions<OrganizationContext> options)
            : base(options)
        {
            // nothing here
        }

        protected override void OnModelCreating(ModelBuilder builder) => base
            .OnModelCreating(builder);

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<ApplicationAnswer> ApplicationAnswers { get; set; }
        public DbSet<ApplicationQuestion> ApplicationQuestions { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<AssessmentQuestion> AssessmentQuestions { get; set; }
        public DbSet<AssessmentAnswer> AssessmentAnswers { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public DbSet<Opening> Openings { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}