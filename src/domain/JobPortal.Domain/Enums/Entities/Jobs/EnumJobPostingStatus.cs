using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Enums.Entities.Jobs
{
    public enum EnumJobPostingStatus
    {
        Pending = -1,
        Closed,
        Open,
        Draft,
        Deleted
    }
}
