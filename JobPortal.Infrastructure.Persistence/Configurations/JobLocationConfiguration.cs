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
    public class JobLocationConfiguration : IEntityTypeConfiguration<JobLocation>
    {
        public void Configure(EntityTypeBuilder<JobLocation> builder)
        {
            builder.ToTable("job_location");
            builder.HasKey(jobLocation => jobLocation.Id);
            builder.Property(jobLocation => jobLocation.Id)
                .HasColumnName("job_location_id")
                .ValueGeneratedOnAdd();

            builder.Property(jobLocation => jobLocation.JobPostingId).HasColumnName("job_posting_id").IsRequired();
            builder.Property(jobLocation => jobLocation.CompanyLocationId).HasColumnName("company_location_id").IsRequired();

            builder.HasOne(jobLocation => jobLocation.JobPosting)
                .WithMany(jobPosting => jobPosting.JobLocations)
                .HasForeignKey(jobLocation => jobLocation.JobPostingId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(jobLocation => jobLocation.CompanyLocation)
                .WithMany(companyLocation => companyLocation.JobLocations)
                .HasForeignKey(jobLocation => jobLocation.CompanyLocationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
