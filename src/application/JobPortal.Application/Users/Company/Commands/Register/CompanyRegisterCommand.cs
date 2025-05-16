using JobPortal.Application.Common.Abstractions.Messaging;
using JobPortal.Application.Common.Dtos.CompanyLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Users.Company.Commands.Register
{
    public class CompanyRegisterCommand : ICommand<Guid>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;
        public string? WebsiteUrl { get; set; } = string.Empty;

        public List<AddCompanyLocationDto> Locations { get; set; } = new List<AddCompanyLocationDto>();
    }
}
