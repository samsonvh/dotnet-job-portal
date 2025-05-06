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
    public class JobSkillConfiguration : IEntityTypeConfiguration<JobSkill>
    {
        public void Configure(EntityTypeBuilder<JobSkill> builder)
        {
            builder.ToTable("job_skill");
            builder.HasKey(jobSkill => jobSkill.Id);
            builder.Property(jobSkill => jobSkill.Id).HasColumnName("job_skill_id").ValueGeneratedOnAdd();

            builder.Property(jobSkill => jobSkill.WorkingSkillId).HasColumnName("working_skill_id").IsRequired();
            builder.Property(jobSkill => jobSkill.JobPostingId).HasColumnName("job_posting_id").IsRequired();

            builder.HasOne(jobSkill => jobSkill.WorkingSkill)
                .WithMany(workingSkill => workingSkill.JobSkills)
                .HasForeignKey(jobSkill => jobSkill.WorkingSkillId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(jobSkill => jobSkill.JobPosting)
                .WithMany(jobPosting => jobPosting.JobSkills)
                .HasForeignKey(jobSkill => jobSkill.JobPostingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
