using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Application.Common.Interfaces.Persistence;

namespace JobPortal.Application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        ICompanyRepository Companies { get; }
        Task<int> SaveAsync(CancellationToken cancellationToken);
    }
}
