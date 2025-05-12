using JobPortal.Application.Common.Interfaces.Repositories;
using JobPortal.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Infrastructure.Persistence.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly JobPortalDbContext _jobPortalDbContext;

        public AccountRepository(JobPortalDbContext jobPortalDbContext)
        {
            _jobPortalDbContext = jobPortalDbContext;
        }

        public async Task AddAsync(Account account)
        {
            await _jobPortalDbContext.Accounts.AddAsync(account);
            await _jobPortalDbContext.SaveChangesAsync();
        }

        public async Task<Account?> GetByEmailAsync(string email)
        {
            return await _jobPortalDbContext.Accounts.FirstOrDefaultAsync(account => account.Email.ToLower() == email.ToLower());
        }

        public async Task<Account?> GetByEmailIncludingProfileAsync(string email)
        {
            return await _jobPortalDbContext.Accounts
                .Include(account => account.Applicant)
                .Include(account => account.Company)
                .Include(account => account.Recruiter)
                .FirstOrDefaultAsync(account => account.Email.ToLower() == email.ToLower());
        }
    }
}
