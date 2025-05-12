using FluentValidation;
using JobPortal.Application.Common.Interfaces.Repositories;
using JobPortal.Application.Common.Interfaces.Services;
using JobPortal.Domain.Enums.Entities.Users.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace JobPortal.Application.Users.Account.Commands.Login
{
    public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;

        private const string EMAIL_REGEX = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        public LoginCommandValidator(IAccountRepository accountRepository, IPasswordHasher passwordHasher)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.");

            RuleFor(x => x)
                .CustomAsync(ValidateAccountAsync)
                .When(x => !string.IsNullOrEmpty(x.Email) && Regex.IsMatch(x.Email, EMAIL_REGEX) && !string.IsNullOrWhiteSpace(x.Password));
        }

        private async Task ValidateAccountAsync(LoginCommand command, ValidationContext<LoginCommand> context, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByEmailAsync(command.Email);
            if (account == null)
            {
                context.AddFailure(nameof(command.Email), "Account with the given email was not found.");
                return;
            }

            if (account.Status != EnumAccountStatus.Pending && account.Status != EnumAccountStatus.Active)
            {
                context.AddFailure(nameof(command.Email), "Account is inactive or deleted.");
                return;
            }

            if (!_passwordHasher.VerifyPassword(command.Password, account.PasswordHash))
            {
                context.AddFailure(nameof(command.Password), "Invalid email or password.");
                return;
            }
        }
    }
}
