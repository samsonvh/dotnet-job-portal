using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities
{
    public class JobLocation : Location
    {
        public Guid Id { get; set; }
        public Guid JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; } = new JobPosting();
    }
}
