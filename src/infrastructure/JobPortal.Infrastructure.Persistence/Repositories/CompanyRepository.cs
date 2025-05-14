using JobPortal.Application.Common.Interfaces.Repositories;
using JobPortal.Domain.Entities.Users.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Infrastructure.Persistence.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly JobPortalDbContext _jobPortalDbContext;

        public CompanyRepository(JobPortalDbContext jobPortalDbContext)
        {
            _jobPortalDbContext = jobPortalDbContext;
        }

        public async Task AddAsync(Company company)
        {
            await _jobPortalDbContext.Companies.AddAsync(company);
            await _jobPortalDbContext.SaveChangesAsync();
        }
    }
}
