using JobPortal.Domain.Entities;
using JobPortal.Domain.Entities.Jobs;
using JobPortal.Domain.Entities.Users;
using JobPortal.Domain.Entities.Users.Applicants;
using JobPortal.Domain.Entities.Users.Companies;
using JobPortal.Domain.Entities.Users.Recruiters;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Infrastructure.Persistence
{
    public class JobPortalDbContext : DbContext
    {
        public JobPortalDbContext(DbContextOptions<JobPortalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<ApplicantResume> ApplicantResumes { get; set; }

        public DbSet<JobPosting> JobPostings { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<JobBenefit> JobBenefits { get; set; }
        public DbSet<JobRequirement> JobRequirements { get; set; }


        public DbSet<WorkingSkill> WorkingSkills { get; set; }
        public DbSet<ApplicantSkill> ApplicantSkills { get; set; }
        public DbSet<JobSkill> JobSkills { get; set; }

        public DbSet<JobLocation> JobLocations { get; set; }
        public DbSet<CompanyLocation> CompanyLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(JobPortalDbContext).Assembly);
        }
    }
}
