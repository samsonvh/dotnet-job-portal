using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities.Users
{
    public class UserSkill
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Guid? ApplicantId { get; set; }
        public Applicant? Applicant { get; set; }
    }
}
