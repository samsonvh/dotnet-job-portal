using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Enums.Statuses
{
    public enum JobPostingStatusEnum
    {
        Draft = -1,
        Closed,
        Open,
        Expired,
        Deleted,
    }
}
