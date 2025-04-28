using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities
{
    public class Location
    {
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? District { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
