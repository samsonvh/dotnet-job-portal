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
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {

            builder.ToTable("company");
            builder.HasKey(company => company.Id);
            builder.Property(company => company.Id).HasColumnName("id");

            builder.Property(company => company.Name).HasColumnName("name").IsRequired();
            builder.Property(company => company.LogoUrl).HasColumnName("logo_url");
            builder.Property(company => company.Description).HasColumnName("description");
            builder.Property(company => company.WebsiteUrl).HasColumnName("website_url");
            builder.Property(company => company.Hotline).HasColumnName("hotline");
            builder.Property(company => company.Industry).HasColumnName("industry");
            builder.Property(company => company.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(company => company.UpdatedAt).HasColumnName("updated_at");

            builder.Property(company => company.Status).HasColumnName("status").HasConversion<int>().IsRequired();

            builder.HasMany(company => company.Locations)
                .WithOne(location => location.Company)
                .HasForeignKey(location => location.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(company => company.JobPostings)
                .WithOne(jobPosting => jobPosting.HiringCompany)
                .HasForeignKey(jobPosting => jobPosting.HiringCompanyId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(company => company.Recruiters)
                .WithOne(recruiter => recruiter.Company)
                .HasForeignKey(recruiter => recruiter.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
