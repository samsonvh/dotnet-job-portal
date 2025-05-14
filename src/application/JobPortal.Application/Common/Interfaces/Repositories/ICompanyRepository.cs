using JobPortal.Domain.Entities.Users.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Common.Interfaces.Repositories
{
    public interface ICompanyRepository
    {
        Task AddAsync(Company company);
    }
}
