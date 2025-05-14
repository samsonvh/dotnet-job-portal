using FluentValidation;
using JobPortal.Application.Common.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Users.Company.Commands.Register
{
    public class CompanyRegisterCommandValidator : AbstractValidator<CompanyRegisterCommand>
    {
        public CompanyRegisterCommandValidator(IAccountRepository accountRepository)
        {
            RuleFor(x => x.Email)
                 .NotEmpty()
                 .EmailAddress()
                 .WithMessage("Invalid email format.")
                 .MustAsync(async (email, cancellation) =>
                 {
                     var account = await accountRepository.GetByEmailAsync(email);
                     return account == null;
                 })
                 .WithMessage("Email already exists.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters long.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone number is required.");

            RuleFor(x => x.WebsiteUrl)
                .Must(url => string.IsNullOrEmpty(url) || Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("Website URL must be a valid URL or empty.");
        }
    }
}
