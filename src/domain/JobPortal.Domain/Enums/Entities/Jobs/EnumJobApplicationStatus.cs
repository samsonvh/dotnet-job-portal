using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Enums.Entities.Jobs
{
    public enum EnumJobApplicationStatus
    {
        Applied = -2,
        Reviewed,
        Rejected,
        Interviewing,
        Offering,
        Hired
    }
}
