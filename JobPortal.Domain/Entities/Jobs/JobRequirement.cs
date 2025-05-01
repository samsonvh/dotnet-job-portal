using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities.Jobs
{
    public class JobRequirement
    {
        public Guid Id { get; set; }

        public string Requirement { get; set; } = string.Empty;
        public int Order { get; set; } = 0;

        public Guid JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; } = new JobPosting();
    }
}
