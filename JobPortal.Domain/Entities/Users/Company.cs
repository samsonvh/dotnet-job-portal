using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.Entities.Jobs;
using JobPortal.Domain.Entities.Locations;
using JobPortal.Domain.Enums.Statuses;

namespace JobPortal.Domain.Entities.Users
{
    public class Company
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? LogoUrl { get; set; }
        public string? Description { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Hotline { get; set; }
        public string? Industry { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public CompanyStatusEnum Status { get; set; } = CompanyStatusEnum.Active;

        public Guid AccountId { get; set; }
        public Account Account { get; set; } = new Account();

        public ICollection<Employer> Employers { get; set; } = new List<Employer>();
        public ICollection<CompanyLocation> Locations { get; set; } = new List<CompanyLocation>();
        public ICollection<JobPosting> PostedJobs { get; set; } = new List<JobPosting>();
    }
}
