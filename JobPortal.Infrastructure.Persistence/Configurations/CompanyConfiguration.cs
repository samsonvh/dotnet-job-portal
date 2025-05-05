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
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("company");
            builder.HasKey(company => company.Id);
            builder.Property(company => company.Id).HasColumnName("company_id").ValueGeneratedOnAdd();

            builder.Property(company => company.Name).HasColumnName("name").IsRequired();
            builder.Property(company => company.Description).HasColumnName("description").IsRequired();
            builder.Property(company => company.PhoneNumber).HasColumnName("phone_number").IsRequired(false);
            builder.Property(company => company.LogoUrl).HasColumnName("logo_url").IsRequired(false);
            builder.Property(company => company.WebsiteUrl).HasColumnName("website_url").IsRequired(false);
            builder.Property(builder => builder.AccountId).HasColumnName("account_id").IsRequired();

            builder.HasOne(company => company.Account)
                .WithOne(account => account.Company)
                .HasForeignKey<Company>(company => company.AccountId)
                .HasConstraintName("fk_company_account_id")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
