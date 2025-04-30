using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortal.Infrastructure.Persistence.Configurations
{
    public class JobPostingConfiguration : IEntityTypeConfiguration<JobPosting>
    {
        public void Configure(EntityTypeBuilder<JobPosting> builder)
        {
            builder.ToTable("job_posting");
            builder.HasKey(jobPosting => jobPosting.Id);
            builder.Property(jobPosting => jobPosting.Id).HasColumnName("job_posting_id");

            builder.Property(jobPosting => jobPosting.Title).HasColumnName("title").IsRequired();
            builder.Property(jobPosting => jobPosting.Description).HasColumnName("description").IsRequired();
            builder.Property(jobPosting => jobPosting.NumberOfHires).HasColumnName("number_of_hires").IsRequired();
            builder.Property(jobPosting => jobPosting.MinSalary).HasColumnName("min_salary");
            builder.Property(jobPosting => jobPosting.MaxSalary).HasColumnName("max_salary");
            builder.Property(jobPosting => jobPosting.Currency).HasColumnName("currency");
            builder.Property(jobPosting => jobPosting.SalaryFrequency).HasColumnName("salary_frequency").HasConversion<int>().IsRequired();
            builder.Property(jobPosting => jobPosting.PostedDate).HasColumnName("posted_date").IsRequired();
            builder.Property(jobPosting => jobPosting.ExpirationDate).HasColumnName("expiration_date");
            builder.Property(jobPosting => jobPosting.Status).HasColumnName("status").HasConversion<int>().IsRequired();

            builder.HasMany(jobPosting => jobPosting.JobLocations)
                .WithOne(location => location.JobPosting)
                .HasForeignKey(location => location.JobPostingId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(jobPosting => jobPosting.JobApplications)
                .WithOne(application => application.JobPosting)
                .HasForeignKey(application => application.JobPostingId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
