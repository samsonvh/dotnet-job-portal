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
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("account");
            builder.HasKey(account => account.Id);
            builder.Property(account => account.Id).HasColumnName("account_id");

            builder.Property(account => account.Email).HasColumnName("email").IsRequired();
            builder.Property(account => account.PasswordHash).HasColumnName("password_hase");
            builder.Property(account => account.Provider).HasColumnName("provider");
            builder.Property(account => account.ProviderUserId).HasColumnName("provider_user_id");
            builder.Property(account => account.CreatedAt).HasColumnName("created_at").IsRequired();

            builder.Property(account => account.Role).HasColumnName("role").HasConversion<int>().IsRequired();
            builder.Property(account => account.Status).HasColumnName("status").HasConversion<int>().IsRequired();

            builder.HasOne(account => account.Company)
                .WithOne(company => company.Account)
                .HasForeignKey<Company>(company => company.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(account => account.UserProfile)
                .WithOne(userProfile => userProfile.Account)
                .HasForeignKey<UserProfile>(userProfile => userProfile.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
