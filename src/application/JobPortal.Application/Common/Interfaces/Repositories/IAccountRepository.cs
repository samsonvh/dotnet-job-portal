using JobPortal.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Common.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<Account?> GetByEmailAsync(string email);    
    }
}
