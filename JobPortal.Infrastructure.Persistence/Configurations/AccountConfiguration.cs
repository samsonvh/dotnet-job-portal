using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.Entities.Users;
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
            builder.Property(account => account.Id).HasColumnName("account_id").ValueGeneratedOnAdd();

            builder.Property(account => account.Email).HasColumnName("email").IsRequired();
            builder.Property(account => account.PasswordHash).HasColumnName("password_hash").IsRequired();
            builder.Property(account => account.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(account => account.UpdatedAt).HasColumnName("updated_at").IsRequired();
            builder.Property(account => account.Role).HasColumnName("role").IsRequired();
            builder.Property(account => account.Status).HasColumnName("status").IsRequired();
            builder.Property(account => account.CreatedById).HasColumnName("created_by_id").IsRequired(false);

            builder.HasMany(account => account.CreatedAccounts)
                .WithOne(account => account.CreatedBy)
                .HasForeignKey(account => account.CreatedById)
                .HasConstraintName("fk_account_created_by_id")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
