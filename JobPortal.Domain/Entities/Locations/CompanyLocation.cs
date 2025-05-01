using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.Entities.Users;
using JobPortal.Domain.Enums.Statuses;

namespace JobPortal.Domain.Entities.Locations
{
    public class CompanyLocation : BaseLocation
    {
        public Guid Id { get; set; }
        public CompanyLocationStatusEnum Status { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = new Company();
    }
}
