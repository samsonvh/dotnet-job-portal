using JobPortal.Domain.Common;
using JobPortal.Domain.Entities.Jobs;
using JobPortal.Domain.Enums.Entities.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities.Users.Companies
{
    public class CompanyLocation : BaseEntity
    {
        public string Address { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public bool IsHeadquarter { get; set; } = false;

        public double? Longitude { get; set; }
        public double? Latitude { get; set; }

        public EnumCompanyLocationStatus Status { get; set; } = EnumCompanyLocationStatus.Active;

        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = new Company();

        public virtual ICollection<JobLocation> JobLocations { get; set; } = new List<JobLocation>();
    }
}
