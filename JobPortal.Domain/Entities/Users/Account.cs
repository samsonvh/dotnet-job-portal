using JobPortal.Domain.Common;
using JobPortal.Domain.Entities.Users.Applicants;
using JobPortal.Domain.Entities.Users.Companies;
using JobPortal.Domain.Entities.Users.Recruiters;
using JobPortal.Domain.Enums.Entities.Users.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities.Users
{
    public class Account : BaseAuditableEntity
    {
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public EnumAccountRole Role { get; set; } = EnumAccountRole.Applicant;
        public EnumAccountStatus Status { get; set; } = EnumAccountStatus.Pending;

        public Guid? CreatedById { get; set; }
        public Account? CreatedBy { get; set; }
        public Company? Company { get; set; }
        public Recruiter? Recruiter { get; set; }
        public Applicant? Applicant { get; set; }

        public virtual ICollection<Account> CreatedAccounts { get; set; } = new List<Account>();
    }
}
