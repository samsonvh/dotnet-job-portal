using JobPortal.Domain.Common;
using JobPortal.Domain.Entities.Users.Recruiters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities.Users.Companies
{
    public class Company : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }
        public string? LogoUrl { get; set; } = string.Empty;
        public string? WebsiteUrl { get; set; } = string.Empty;

        public Guid AccountId { get; set; }
        public Account Account { get; set; } = new Account();

        public virtual ICollection<CompanyLocation> CompanyLocations { get; set; } = new List<CompanyLocation>();
        public virtual ICollection<Recruiter> Recruiters { get; set; } = new List<Recruiter>();
    }
}
