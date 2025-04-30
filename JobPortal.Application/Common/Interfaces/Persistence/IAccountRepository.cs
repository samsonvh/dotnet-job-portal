using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.Entities;

namespace JobPortal.Application.Common.Interfaces.Persistence
{
    public interface IAccountRepository
    {
        Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken);
        Task AddAsync(Account account, CancellationToken cancellationToken);
    }
}
