using JobPortal.Domain.Enums;
using JobPortal.Domain.Enums.Statuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities
{
    public class JobPosting
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int NumberOfHires { get; set; } = 1;
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }
        public string? Currency { get; set; }
        public SalaryFrequency SalaryFrequency { get; set; } = SalaryFrequency.Negotiable;
        public DateTime PostedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ExpirationDate { get; set; }
        public JobPostingStatus Status { get; set; } = JobPostingStatus.Draft;

        public ICollection<JobLocation> JobLocations { get; set; } = new List<JobLocation>();
        public ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();

        public Guid HiringCompanyId { get; set; }
        public Company HiringCompany { get; set; } = new Company();
        public Guid RecruiterId { get; set; }
        public UserProfile Recruiter { get; set; } = new UserProfile();
    }
}
