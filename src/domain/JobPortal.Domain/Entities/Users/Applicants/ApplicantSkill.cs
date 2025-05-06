using JobPortal.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities.Users.Applicants
{
    public class ApplicantSkill : BaseEntity
    {
        public Guid WorkingSkillId { get; set; }
        public WorkingSkill WorkingSkill { get; set; } = new WorkingSkill();
        public Guid ApplicantId { get; set; }
        public Applicant Applicant { get; set; } = new Applicant();
    }
}
