using JobPortal.Domain.Common;
using JobPortal.Domain.Entities.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities.Users.Applicants
{
    public class Applicant : UserProfile
    {
        public string? Bio { get; set; }

        public Guid AccountId { get; set; }
        public Account Account { get; set; } = new Account();

        public virtual ICollection<ApplicantSkill> ApplicantSkills { get; set; } = new List<ApplicantSkill>();
        public virtual ICollection<ApplicantResume> ApplicantResumes { get; set; } = new List<ApplicantResume>();
        public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
    }
}
