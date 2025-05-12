using JobPortal.Application.Common.Interfaces.Repositories;
using JobPortal.Application.Common.Interfaces.Services;
using JobPortal.Domain.Enums.Entities.Users.Account;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Users.Applicant.Commands.Register
{
    public class ApplicantRegisterCommandHandler(IAccountRepository accountRepository, IApplicantRepository applicantRepository, ISequentialGuidGenerator sequentialGuidGenerator, IPasswordHasher passwordHasher) : IRequestHandler<ApplicantRegisterCommand, Guid>
    {
        public async Task<Guid> Handle(ApplicantRegisterCommand request, CancellationToken cancellationToken)
        {
            var account = new JobPortal.Domain.Entities.Users.Account
            {
                Id = sequentialGuidGenerator.GenerateSequentialGuid(),
                Email = request.Email,
                PasswordHash = passwordHasher.HashPassword(request.Password),
                Role = EnumAccountRole.Applicant,
                Status = EnumAccountStatus.Pending,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            var applicant = new JobPortal.Domain.Entities.Users.Applicants.Applicant
            {
                Id = sequentialGuidGenerator.GenerateSequentialGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                DateOfBirth = request.DateOfBirth,
                Bio = request.Bio,
                Account = account
            };

            await accountRepository.AddAsync(account);
            await applicantRepository.AddAsync(applicant);

            return applicant.Id;
        }
    }
}
