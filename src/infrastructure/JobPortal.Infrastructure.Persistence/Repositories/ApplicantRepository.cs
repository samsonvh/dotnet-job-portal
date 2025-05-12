using JobPortal.Application.Common.Interfaces.Repositories;
using JobPortal.Domain.Entities.Users.Applicants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Infrastructure.Persistence.Repositories
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly JobPortalDbContext _jobPortalDbContext;

        public ApplicantRepository(JobPortalDbContext jobPortalDbContext)
        {
            _jobPortalDbContext = jobPortalDbContext;
        }

        public async Task AddAsync(Applicant applicant)
        {
            await _jobPortalDbContext.Applicants.AddAsync(applicant);
            await _jobPortalDbContext.SaveChangesAsync();
        }
    }
}
