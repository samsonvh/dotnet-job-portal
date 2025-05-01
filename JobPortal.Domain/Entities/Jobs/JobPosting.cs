using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.Entities.Applications;
using JobPortal.Domain.Entities.Locations;
using JobPortal.Domain.Entities.Users;
using JobPortal.Domain.Enums;
using JobPortal.Domain.Enums.Statuses;

namespace JobPortal.Domain.Entities.Jobs
{
    public class JobPosting
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int NumberOfHires { get; set; } = 1;

        public int MinSalary { get; set; } = 0;
        public int MaxSalary { get; set; } = 0;
        public string? Currency { get; set; }
        public SalaryTypeEnum SalaryType { get; set; } = SalaryTypeEnum.Negotiable;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? PostedDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public JobPostingStatusEnum Status { get; set; } = JobPostingStatusEnum.Draft;

        public Guid EmployerId { get; set; }
        public Employer Employer { get; set; } = new Employer();
        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = new Company();

        public ICollection<JobLocation> JobLocations { get; set; } = new List<JobLocation>();
        public ICollection<JobRequirement> JobRequirements { get; set; } = new List<JobRequirement>();
        public ICollection<JobBenefit> JobBenefits { get; set; } = new List<JobBenefit>();
        public ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
    }
}
