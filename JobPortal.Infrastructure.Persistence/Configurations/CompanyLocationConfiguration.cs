using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.Entities.Users.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortal.Infrastructure.Persistence.Configurations
{
    public class CompanyLocationConfiguration : IEntityTypeConfiguration<CompanyLocation>
    {
        public void Configure(EntityTypeBuilder<CompanyLocation> builder)
        {
            builder.ToTable("company_location");
            builder.HasKey(companyLocation => companyLocation.Id);
            builder.Property(companyLocation => companyLocation.Id).HasColumnName("company_location_id").ValueGeneratedOnAdd();

            builder.Property(companyLocation => companyLocation.Address).HasColumnName("address").IsRequired();
            builder.Property(companyLocation => companyLocation.District).HasColumnName("district").IsRequired();
            builder.Property(companyLocation => companyLocation.City).HasColumnName("city").IsRequired();
            builder.Property(companyLocation => companyLocation.Country).HasColumnName("country").IsRequired();
            builder.Property(companyLocation => companyLocation.IsHeadquarter).HasColumnName("is_headquarter").IsRequired();
            builder.Property(companyLocation => companyLocation.Longitude).HasColumnName("longitude").IsRequired(false);
            builder.Property(companyLocation => companyLocation.Latitude).HasColumnName("latitude").IsRequired(false);
            builder.Property(companyLocation => companyLocation.Status).HasColumnName("status").IsRequired();

            builder.HasOne(companyLocation => companyLocation.Company)
                .WithMany(company => company.CompanyLocations)
                .HasForeignKey(companyLocation => companyLocation.CompanyId)
                .HasConstraintName("fk_company_location_company_id")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
