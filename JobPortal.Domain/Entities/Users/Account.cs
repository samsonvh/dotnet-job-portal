using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.Enums;
using JobPortal.Domain.Enums.Statuses;

namespace JobPortal.Domain.Entities.Users
{
    public class Account
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
        public string ProviderUserId { get; set; } = string.Empty;
        public UserRoleEnum Role { get; set; } = UserRoleEnum.Applicant;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public AccountStatusEnum Status { get; set; } = AccountStatusEnum.PendingVerification;

        public Guid? CompanyId { get; set; }
        public Company? Company { get; set; }
        public Guid? EmployerId { get; set; }
        public Employer? Employer { get; set; }
        public Guid? ApplicantId { get; set; }
        public Applicant? Applicant { get; set; }
    }
}
