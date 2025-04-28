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
        public ICollection<CompanyLocation> CompanyLocations { get; set; } = new List<CompanyLocation>();
        public CompanyStatus Status { get; set; }

        public ICollection<JobPosting> JobPostings { get; set; } = new List<JobPosting>();
    }
}
