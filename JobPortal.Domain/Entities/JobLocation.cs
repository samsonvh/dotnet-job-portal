using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities
{
    public class JobLocation : Location
    {
        public Guid JobId { get; set; }
        public Job Job { get; set; } = new Job();
    }
}
