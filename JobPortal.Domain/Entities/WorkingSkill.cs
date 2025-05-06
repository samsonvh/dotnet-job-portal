using JobPortal.Domain.Common;
using JobPortal.Domain.Entities.Jobs;
using JobPortal.Domain.Entities.Users.Applicants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities
{
    public class WorkingSkill : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<JobSkill> JobSkills { get; set; } = new List<JobSkill>();
        public virtual ICollection<ApplicantSkill> ApplicantSkills { get; set; } = new List<ApplicantSkill>();
    }
}
