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
        public int NumberOfHires { get; set; }
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }
        public string Currency { get; set; } = string.Empty;
        public SalaryFrequency SalaryFrequency { get; set; } = SalaryFrequency.Monthly;
        public ICollection<JobLocation> JobLocations { get; set; } = new List<JobLocation>();
        public DateTime PostedDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public JobPostingStatus Status { get; set; } = JobPostingStatus.PendingForApproval;

        public ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();

        public Guid HiringCompanyId { get; set; }
        public Company HiringCompany { get; set; } = new Company();
        public Guid RecruiterId { get; set; }
        public UserProfile Recruiter { get; set; } = new UserProfile();
    }
}
