using JobPortal.Domain.Common;
using JobPortal.Domain.Entities.Jobs;
using JobPortal.Domain.Entities.Users.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities.Users.Recruiters
{
    public class Recruiter : UserProfile
    {
        public Guid AccountId { get; set; }
        public Account Account { get; set; } = new Account();
        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = new Company();

        public virtual ICollection<JobPosting> JobPostings { get; set; } = new List<JobPosting>();
    }
}
