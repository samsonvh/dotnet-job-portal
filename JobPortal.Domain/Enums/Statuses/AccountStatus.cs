using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Enums.Statuses
{
    public enum AccountStatus
    {
        PendingVerification,
        Active,
        Inactive,
        Suspended,
        Deleted,
    }
}
