using JobPortal.Application.Common.Exceptions;
using JobPortal.Application.Common.Interfaces.Repositories;
using JobPortal.Application.Common.Interfaces.Services;
using JobPortal.Domain.Entities.Users;
using JobPortal.Domain.Enums.Entities.Users.Account;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Users.Account.Commands.Login
{
    public class LoginCommandHandler(IAccountRepository accountRepository, IPasswordHasher passwordHasher, IJwtGenerator jwtGenerator) : IRequestHandler<LoginCommand, LoginResult>
    {
        public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var account = await accountRepository.GetByEmailIncludingProfileAsync(request.Email);

            var loginResult = new LoginResult
            {
                Token = jwtGenerator.GenerateJwtToken(account!.Id, account.Email, account.Role),
                Email = account.Email,
                Role = account.Role,
            };

            switch (account.Role)
            {
                case EnumAccountRole.Applicant:
                    loginResult.FirstName = account.Applicant?.FirstName;
                    loginResult.LastName = account.Applicant?.LastName;
                    break;
                case EnumAccountRole.Company:
                    loginResult.FirstName = account.Company?.Name;
                    break;
                case EnumAccountRole.Recruiter:
                    loginResult.FirstName = account.Recruiter?.FirstName;
                    loginResult.LastName = account.Recruiter?.LastName;
                    break;
                default:
                    break;
            }

            return loginResult;
        }
    }
}
