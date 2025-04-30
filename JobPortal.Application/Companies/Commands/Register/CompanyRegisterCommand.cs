using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Application.Common.DTOs;
using JobPortal.Application.Companies.DTOs;
using MediatR;

namespace JobPortal.Application.Companies.Commands.Register
{
    public class CompanyRegisterCommand : IRequest<CommonResult>
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
