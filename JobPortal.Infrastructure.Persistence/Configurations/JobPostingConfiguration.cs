using JobPortal.Domain.Entities.Jobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Infrastructure.Persistence.Configurations
{
    public class JobPostingConfiguration : IEntityTypeConfiguration<JobPosting>
    {
        public void Configure(EntityTypeBuilder<JobPosting> builder)
        {
            builder.ToTable("job_posting");
            builder.HasKey(jobPosting => jobPosting.Id);
            builder.Property(jobPosting => jobPosting.Id)
                .HasColumnName("job_posting_id")
                .ValueGeneratedOnAdd();

            builder.Property(jobPosting => jobPosting.Title).HasColumnName("title").IsRequired();
            builder.Property(jobPosting => jobPosting.Description).HasColumnName("description").IsRequired();
            builder.Property(jobPosting => jobPosting.NumberOfHires).HasColumnName("number_of_hires").IsRequired();
            builder.Property(jobPosting => jobPosting.MinSalary).HasColumnName("min_salary").IsRequired();
            builder.Property(jobPosting => jobPosting.MaxSalary).HasColumnName("max_salary").IsRequired();
            builder.Property(jobPosting => jobPosting.Currency).HasColumnName("currency").IsRequired();

            builder.Property(jobPosting => jobPosting.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(jobPosting => jobPosting.UpdatedAt).HasColumnName("updated_at").IsRequired();
            builder.Property(jobPosting => jobPosting.PostedAt).HasColumnName("posted_at").IsRequired();
            builder.Property(jobPosting => jobPosting.ExpiryDate).HasColumnName("expiry_date").IsRequired();

            builder.Property(jobPosting => jobPosting.SalaryType).HasColumnName("salary_type").IsRequired();
            builder.Property(jobPosting => jobPosting.JobType).HasColumnName("job_type").IsRequired();
            builder.Property(jobPosting => jobPosting.JobLevel).HasColumnName("job_level").IsRequired();
            builder.Property(jobPosting => jobPosting.Status).HasColumnName("status").IsRequired();

            builder.Property(jobPosting => jobPosting.CreatedById).HasColumnName("created_by_id").IsRequired();

            builder.HasOne(jobPosting => jobPosting.CreatedBy)
                .WithMany(recruiter => recruiter.JobPostings)
                .HasForeignKey(jobPosting => jobPosting.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
