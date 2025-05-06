using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.Entities.Users.Recruiters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortal.Infrastructure.Persistence.Configurations
{
    public class RecruiterConfiguration : IEntityTypeConfiguration<Recruiter>
    {
        public void Configure(EntityTypeBuilder<Recruiter> builder)
        {
            builder.ToTable("recruiter");
            builder.HasKey(recruiter => recruiter.Id);
            builder.Property(recruiter => recruiter.Id).HasColumnName("recruiter_id").ValueGeneratedOnAdd();

            builder.Property(recruiter => recruiter.FirstName).HasColumnName("first_name").IsRequired();
            builder.Property(recruiter => recruiter.LastName).HasColumnName("last_name").IsRequired();
            builder.Property(recruiter => recruiter.PhoneNumber).HasColumnName("phone_number").IsRequired();
            builder.Property(recruiter => recruiter.DateOfBirth).HasColumnName("date_of_birth").IsRequired();
            builder.Property(recruiter => recruiter.AccountId).HasColumnName("account_id").IsRequired();
            builder.Property(recruiter => recruiter.CompanyId).HasColumnName("company_id").IsRequired();

            builder.HasOne(recruiter => recruiter.Account)
                .WithOne(account => account.Recruiter)
                .HasForeignKey<Recruiter>(recruiter => recruiter.AccountId)
                .HasConstraintName("fk_recruiter_account_id")
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(recruiter => recruiter.Company)
                .WithMany(company => company.Recruiters)
                .HasForeignKey(recruiter => recruiter.CompanyId)
                .HasConstraintName("fk_recruiter_company_id")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
