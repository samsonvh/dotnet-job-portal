using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.Entities.Jobs;

namespace JobPortal.Domain.Entities.Users
{
    public class Employer : BaseUserProfile
    {
        public Guid? CompanyId { get; set; }
        public Company? Company { get; set; }

        public ICollection<JobPosting> PostedJobs { get; set; } = new List<JobPosting>();
    }
}
