using JobPortal.Domain.Entities.Users.Applicants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Infrastructure.Persistence.Configurations
{
    public class ApplicantSkillConfiguration : IEntityTypeConfiguration<ApplicantSkill>
    {
        public void Configure(EntityTypeBuilder<ApplicantSkill> builder)
        {
            builder.ToTable("applicant_skill");
            builder.HasKey(applicantSkill => applicantSkill.Id);
            builder.Property(applicantSkill => applicantSkill.Id).HasColumnName("applicant_skill_id").ValueGeneratedOnAdd();

            builder.Property(applicantSkill => applicantSkill.ApplicantId).HasColumnName("applicant_id").IsRequired();
            builder.Property(applicantSkill => applicantSkill.WorkingSkillId).HasColumnName("working_skill_id").IsRequired();

            builder.HasOne(applicantSkill => applicantSkill.Applicant)
                .WithMany(applicant => applicant.ApplicantSkills)
                .HasForeignKey(applicantSkill => applicantSkill.ApplicantId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(applicantSkill => applicantSkill.WorkingSkill)
                .WithMany(workingSkill => workingSkill.ApplicantSkills)
                .HasForeignKey(applicantSkill => applicantSkill.WorkingSkillId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
