using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Common
{
    public abstract class UserProfile : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
