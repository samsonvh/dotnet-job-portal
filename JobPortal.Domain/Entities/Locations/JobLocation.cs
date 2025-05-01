using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.Entities.Jobs;

namespace JobPortal.Domain.Entities.Locations
{
    public class JobLocation
    {
        public Guid Id { get; set; }

        public Guid CompanyLocationId { get; set; }
        public CompanyLocation CompanyLocation { get; set; } = new CompanyLocation();
        public Guid JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; } = new JobPosting();
    }
}
