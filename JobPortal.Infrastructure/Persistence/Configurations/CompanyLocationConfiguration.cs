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
    public class CompanyLocationConfiguration : IEntityTypeConfiguration<CompanyLocation>
    {
        public void Configure(EntityTypeBuilder<CompanyLocation> builder)
        {
            builder.ToTable("company_location");
            builder.HasKey(location => location.Id);
            builder.Property(location => location.Id).HasColumnName("company_location_id");

            builder.Property(location => location.Address).HasColumnName("address").IsRequired();
            builder.Property(location => location.District).HasColumnName("district").IsRequired();
            builder.Property(location => location.City).HasColumnName("city").IsRequired();
            builder.Property(location => location.Country).HasColumnName("country").IsRequired();
            builder.Property(location => location.State).HasColumnName("state");
            builder.Property(location => location.ZipCode).HasColumnName("zip_code");
            builder.Property(location => location.Latitude).HasColumnName("latitude");
            builder.Property(location => location.Longitude).HasColumnName("longitude");
        }
    }
}
