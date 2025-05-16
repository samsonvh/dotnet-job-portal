using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Common.Dtos.CompanyLocation
{
    public class AddCompanyLocationDto
    {
        public string Address { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public bool IsHeadquarter { get; set; } = false;

        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
    }
}
