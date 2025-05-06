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
    public class JobBenefitConfiguration : IEntityTypeConfiguration<JobBenefit>
    {
        public void Configure(EntityTypeBuilder<JobBenefit> builder)
        {
            builder.ToTable("job_benefit");
            builder.HasKey(jobBenefit => jobBenefit.Id);
            builder.Property(jobBenefit => jobBenefit.Id).HasColumnName("job_benefit_id").ValueGeneratedOnAdd();

            builder.Property(jobBenefit => jobBenefit.JobPostingId).HasColumnName("job_posting_id").IsRequired();
            builder.Property(jobBenefit => jobBenefit.Benefit).HasColumnName("benefit").IsRequired();

            builder.HasOne(jobBenefit => jobBenefit.JobPosting)
                .WithMany(jobPosting => jobPosting.JobBenefits)
                .HasForeignKey(jobBenefit => jobBenefit.JobPostingId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
