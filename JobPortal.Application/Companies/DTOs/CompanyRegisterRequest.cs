using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Companies.DTOs
{
    public class CompanyRegisterRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Hotline { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Industry { get; set; }
        public string? WebsiteUrl { get; set; }
        public ICollection<CompanyLocationDTO> Locations { get; set; } = new List<CompanyLocationDTO>();
    }
}
