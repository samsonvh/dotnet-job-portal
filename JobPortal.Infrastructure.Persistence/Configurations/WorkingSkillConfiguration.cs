using JobPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Infrastructure.Persistence.Configurations
{
    public class WorkingSkillConfiguration : IEntityTypeConfiguration<WorkingSkill>
    {
        public void Configure(EntityTypeBuilder<WorkingSkill> builder)
        {
            builder.ToTable("working_skill");
            builder.HasKey(workingSkill => workingSkill.Id);
            builder.Property(workingSkill => workingSkill.Id)
                .HasColumnName("working_skill_id")
                .ValueGeneratedOnAdd();

            builder.Property(workingSkill => workingSkill.Name).HasColumnName("name").IsRequired();
        }
    }
}
