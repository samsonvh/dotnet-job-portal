using JobPortal.Domain.Common;
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

        public EnumAccountRole MyProperty { get; set; } = EnumAccountRole.Applicant;
        public EnumAccountStatus Status { get; set; } = EnumAccountStatus.Pending;

        public Guid? CreatedById { get; set; }
        public Account? CreatedBy { get; set; }
    }
}
