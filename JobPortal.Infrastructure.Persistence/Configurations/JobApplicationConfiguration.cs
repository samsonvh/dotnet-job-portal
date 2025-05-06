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
    public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
    {
        public void Configure(EntityTypeBuilder<JobApplication> builder)
        {
            builder.ToTable("job_application");
            builder.HasKey(jobApplication => jobApplication.Id);
            builder.Property(jobApplication => jobApplication.Id)
                .HasColumnName("job_application_id")
                .ValueGeneratedOnAdd();

            builder.Property(jobApplication => jobApplication.Status)
                .HasColumnName("status")
                .IsRequired();
            builder.Property(jobApplication => jobApplication.CoverLetter).HasColumnName("cover_letter").IsRequired(false);
            builder.Property(jobApplication => jobApplication.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(jobApplication => jobApplication.UpdatedAt).HasColumnName("updated_at").IsRequired();

            builder.Property(jobApplication => jobApplication.JobPostingId)
                .HasColumnName("job_posting_id")
                .IsRequired();
            builder.Property(jobApplication => jobApplication.ApplicantId)
                .HasColumnName("applicant_id")
                .IsRequired();
            builder.Property(jobApplication => jobApplication.ApplicantResumeId)
                .HasColumnName("applicant_resume_id")
                .IsRequired();

            builder.HasOne(jobApplication => jobApplication.JobPosting)
                .WithMany(jobPosting => jobPosting.JobApplications)
                .HasForeignKey(jobApplication => jobApplication.JobPostingId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(jobApplication => jobApplication.Applicant)
                .WithMany(applicant => applicant.JobApplications)
                .HasForeignKey(jobApplication => jobApplication.ApplicantId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(jobApplication => jobApplication.ApplicantResume)
                .WithMany(applicantResume => applicantResume.JobApplications)
                .HasForeignKey(jobApplication => jobApplication.ApplicantResumeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
