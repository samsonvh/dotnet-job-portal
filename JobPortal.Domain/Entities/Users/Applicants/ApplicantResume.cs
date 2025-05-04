using JobPortal.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities.Users.Applicants
{
    public class ApplicantResume : BaseAuditableEntity
    {
        public string FileName { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;

        public Guid ApplicantId { get; set; }
        public Applicant Applicant { get; set; } = new Applicant();
    }
}
