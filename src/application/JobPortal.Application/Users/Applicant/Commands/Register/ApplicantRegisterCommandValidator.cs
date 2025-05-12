using FluentValidation;
using JobPortal.Application.Common.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Users.Applicant.Commands.Register
{
    public class ApplicantRegisterCommandValidator : AbstractValidator<ApplicantRegisterCommand>
    {
        public ApplicantRegisterCommandValidator(IAccountRepository accountRepository)
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
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters long.");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone number is required.");
        }
    }
}
