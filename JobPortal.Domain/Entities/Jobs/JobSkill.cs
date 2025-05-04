using JobPortal.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities.Jobs
{
    public class JobSkill : BaseEntity
    {
        public Guid WorkingSkillId { get; set; }
        public WorkingSkill WorkingSkill { get; set; } = new WorkingSkill();
        public Guid JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; } = new JobPosting();
    }
}
