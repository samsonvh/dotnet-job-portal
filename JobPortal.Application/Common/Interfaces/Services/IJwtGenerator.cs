using JobPortal.Domain.Enums.Entities.Users.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Common.Interfaces.Services
{
    public interface IJwtGenerator
    {
        string GenerateJwtToken(Guid accountId, string email, EnumAccountRole role);
    }
}
