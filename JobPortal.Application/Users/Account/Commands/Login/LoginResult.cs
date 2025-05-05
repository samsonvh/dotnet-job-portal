using JobPortal.Domain.Enums.Entities.Users.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Users.Account.Commands.Login
{
    public class LoginResult
    {
        public string Token { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? FirstName { get; set; };
        public string? LastName { get; set; }
        public EnumAccountRole Role { get; set; } = EnumAccountRole.Applicant;
    }
}
