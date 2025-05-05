using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.Entities.Users.Applicants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortal.Infrastructure.Persistence.Configurations
{
    public class ApplicantResumeConfiguration : IEntityTypeConfiguration<ApplicantResume>
    {
        public void Configure(EntityTypeBuilder<ApplicantResume> builder)
        {
            builder.ToTable("applicant_resume");
            builder.HasKey(resume => resume.Id);
            builder.Property(resume => resume.Id).HasColumnName("resume_id").ValueGeneratedOnAdd();

            builder.Property(resume => resume.FileName).HasColumnName("file_name").IsRequired();
            builder.Property(resume => resume.FileUrl).HasColumnName("file_url").IsRequired();
            builder.Property(resume => resume.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(resume => resume.UpdatedAt).HasColumnName("updated_at").IsRequired();
            builder.Property(resume => resume.ApplicantId).HasColumnName("applicant_id").IsRequired();

            builder.HasOne(resume => resume.Applicant)
                .WithMany(applicant => applicant.ApplicantResumes)
                .HasForeignKey(resume => resume.ApplicantId)
                .HasConstraintName("fk_applicant_resume_applicant_id")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
