using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.Entities.Jobs;
using JobPortal.Domain.Entities.Users;
using JobPortal.Domain.Enums.Statuses;

namespace JobPortal.Domain.Entities.Applications
{
    public class JobApplication
    {
        public Guid Id { get; set; }

        public string? CoverLetter { get; set; }
        public DateTime AppliedAt { get; set; } = DateTime.UtcNow;
        public JobApplicationStatusEnum Status { get; set; } = JobApplicationStatusEnum.Pending;

        public Guid ResumeId { get; set; }
        public Resume Resume { get; set; } = new Resume();
        public Guid ApplicantId { get; set; }
        public Applicant Applicant { get; set; } = new Applicant();
        public Guid JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; } = new JobPosting();
    }
}
