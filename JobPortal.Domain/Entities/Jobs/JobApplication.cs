using JobPortal.Domain.Common;
using JobPortal.Domain.Entities.Users.Applicants;
using JobPortal.Domain.Enums.Entities.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities.Jobs
{
    public class JobApplication : BaseAuditableEntity
    {
        public string? CoverLetter { get; set; }

        public EnumJobApplicationStatus Status { get; set; } = EnumJobApplicationStatus.Applied;

        public Guid ApplicantId { get; set; }
        public Applicant Applicant { get; set; } = new Applicant();
        public Guid ApplicantResumeId { get; set; }
        public ApplicantResume ApplicantResume { get; set; } = new ApplicantResume();
        public Guid JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; } = new JobPosting();
    }
}
