using JobPortal.Application.Common.Interfaces.Repositories;
using JobPortal.Application.Common.Interfaces.Services;
using JobPortal.Domain.Enums.Entities.Users.Account;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Users.Company.Commands.Register
{
    public class CompanyRegisterCommandHandler(IAccountRepository accountRepository, ICompanyRepository companyRepository, ISequentialGuidGenerator sequentialGuidGenerator, IPasswordHasher passwordHasher) : IRequestHandler<CompanyRegisterCommand, Guid>
    {
        public async Task<Guid> Handle(CompanyRegisterCommand request, CancellationToken cancellationToken)
        {
            var account = new JobPortal.Domain.Entities.Users.Account
            {
                Id = sequentialGuidGenerator.GenerateSequentialGuid(),
                Email = request.Email,
                PasswordHash = passwordHasher.HashPassword(request.Password),
                Role = EnumAccountRole.Company,
                Status = EnumAccountStatus.Pending,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            var company = new JobPortal.Domain.Entities.Users.Companies.Company
            {
                Id = sequentialGuidGenerator.GenerateSequentialGuid(),
                Name = request.Name,
                Description = request.Description,
                PhoneNumber = request.PhoneNumber,
                WebsiteUrl = request.WebsiteUrl,
                Account = account
            };

            await accountRepository.AddAsync(account);
            await companyRepository.AddAsync(company);

            return company.Id;
        }
    }
}
