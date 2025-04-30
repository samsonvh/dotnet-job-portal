using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.Enums.Statuses;

namespace JobPortal.Domain.Entities
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
        public CompanyStatus Status { get; set; } = CompanyStatus.Active;

        public Guid AccountId { get; set; }
        public Account Account { get; set; } = new Account();

        public ICollection<CompanyLocation> Locations { get; set; } = new List<CompanyLocation>();
        public ICollection<JobPosting> JobPostings { get; set; } = new List<JobPosting>();
        public ICollection<UserProfile> Recruiters { get; set; } = new List<UserProfile>();
    }
}
