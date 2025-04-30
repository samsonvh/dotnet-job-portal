using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Companies.DTOs
{
    public class CompanyLocationDTO
    {
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
    }
}
