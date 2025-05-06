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
    public class JobRequirementConfiguration : IEntityTypeConfiguration<JobRequirement>
    {
        public void Configure(EntityTypeBuilder<JobRequirement> builder)
        {
            builder.ToTable("job_requirement");
            builder.HasKey(jobRequirement => jobRequirement.Id);
            builder.Property(jobRequirement => jobRequirement.Id).HasColumnName("job_requirement_id").ValueGeneratedOnAdd();

            builder.Property(jobRequirement => jobRequirement.JobPostingId).HasColumnName("job_posting_id").IsRequired();
            builder.Property(jobRequirement => jobRequirement.Requirement).HasColumnName("requirement").IsRequired();

            builder.HasOne(jobRequirement => jobRequirement.JobPosting)
                .WithMany(jobPosting => jobPosting.JobRequirements)
                .HasForeignKey(jobRequirement => jobRequirement.JobPostingId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
