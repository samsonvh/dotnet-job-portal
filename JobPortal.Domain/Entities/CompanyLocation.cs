using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities
{
    public class CompanyLocation : Location
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = new Company();
    }
}
