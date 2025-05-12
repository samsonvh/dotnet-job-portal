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
            var account = await accountRepository.GetByEmailAsync(request.Email);

            return new LoginResult
            {
                Token = jwtGenerator.GenerateJwtToken(account!.Id, account.Email, account.Role),
                Email = account.Email,
                Role = account.Role
            };
        }

        private bool IsPasswordValid(string password, string hashedPassword) => passwordHasher.VerifyPassword(password, hashedPassword);

        private bool IsAccountActive(EnumAccountStatus status) => status is EnumAccountStatus.Active or EnumAccountStatus.Pending;
    }
}
