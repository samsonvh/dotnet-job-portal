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
    public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.ToTable("applicant");
            builder.HasKey(applicant => applicant.Id);
            builder.Property(applicant => applicant.Id).HasColumnName("applicant_id").ValueGeneratedOnAdd();

            builder.Property(applicant => applicant.AccountId).HasColumnName("account_id").IsRequired();
            builder.Property(applicant => applicant.FirstName).HasColumnName("first_name").IsRequired();
            builder.Property(applicant => applicant.LastName).HasColumnName("last_name").IsRequired();
            builder.Property(applicant => applicant.PhoneNumber).HasColumnName("phone_number").IsRequired();
            builder.Property(applicant => applicant.DateOfBirth).HasColumnName("date_of_birth").IsRequired();
            builder.Property(applicant => applicant.Bio).HasColumnName("bio").IsRequired(false);
            builder.Property(applicant => applicant.AccountId).HasColumnName("account_id").IsRequired();

            builder.HasOne(applicant => applicant.Account)
                .WithOne(account => account.Applicant)
                .HasForeignKey<Applicant>(applicant => applicant.AccountId)
                .HasConstraintName("fk_applicant_account_id")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
