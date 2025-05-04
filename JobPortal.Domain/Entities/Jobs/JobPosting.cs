using JobPortal.Domain.Common;
using JobPortal.Domain.Entities.Users.Recruiters;
using JobPortal.Domain.Enums.Entities.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities.Jobs
{
    public class JobPosting : BaseAuditableEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int NumberOfHires { get; set; } = 1;
        public int MinSalary { get; set; } = 0;
        public int MaxSalary { get; set; } = 0;
        public string Currency { get; set; } = "VND";

        public DateTimeOffset? PostedAt { get; set; }
        public DateTimeOffset? ExpiryDate { get; set; }

        public EnumSalaryType SalaryType { get; set; } = EnumSalaryType.Negotiable;
        public EnumJobType JobType { get; set; } = EnumJobType.FullTime;
        public EnumJobLevel JobLevel { get; set; } = EnumJobLevel.MidLevel;
        public EnumJobPostingStatus Status { get; set; } = EnumJobPostingStatus.Draft;

        public Guid CreatedById { get; set; }
        public Recruiter CreatedBy { get; set; } = new Recruiter();

        public virtual ICollection<JobLocation> JobLocations { get; set; } = new List<JobLocation>();
        public virtual ICollection<JobRequirement> JobRequirements { get; set; } = new List<JobRequirement>();
        public virtual ICollection<JobBenefit> JobBenefits { get; set; } = new List<JobBenefit>();
        public virtual ICollection<JobSkill> JobSkills { get; set; } = new List<JobSkill>();
        public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
    }
}
