using JobPortal.Domain.Common;
using JobPortal.Domain.Entities.Users.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities.Jobs
{
    public class JobLocation : BaseEntity
    {
        public Guid CompanyLocationId { get; set; }
        public CompanyLocation CompanyLocation { get; set; } = new CompanyLocation();
        public Guid JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; } = new JobPosting();
    }
}
