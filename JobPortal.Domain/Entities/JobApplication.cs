using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities
{
    public class JobApplication
    {
        public Guid Id { get; set; }
        public string? CoverLetter { get; set; }
        public DateTime SubmissionDate { get; set; }

        public Guid JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; } = new JobPosting();
        public Guid ApplicantId { get; set; }
        public UserProfile Applicant { get; set; } = new UserProfile();
        public Guid ResumeId { get; set; }
        public Resume Resume { get; set; } = new Resume();
    }
}
