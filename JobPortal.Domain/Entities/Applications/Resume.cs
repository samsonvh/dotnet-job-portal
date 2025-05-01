using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.Entities.Users;

namespace JobPortal.Domain.Entities.Applications
{
    public class Resume
    {
        public Guid Id { get; set; }

        public string? FilePath { get; set; }
        public string? FileName { get; set; }
        public string? FileType { get; set; }
        public long FileSize { get; set; }

        public Guid ApplicantId { get; set; }
        public Applicant Applicant { get; set; } = new Applicant();
    }
}
