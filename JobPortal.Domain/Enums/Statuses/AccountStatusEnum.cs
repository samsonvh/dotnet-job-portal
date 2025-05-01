using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Enums.Statuses
{
    public enum AccountStatusEnum
    {
        PendingVerification = -1,
        Inactive,
        Active,
        Suspended,
        Deleted,
    }
}
