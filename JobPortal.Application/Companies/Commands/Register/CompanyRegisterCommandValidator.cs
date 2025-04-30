using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobPortal.Application.Companies.DTOs;

namespace JobPortal.Application.Companies.Commands.Register
{
    public class CompanyLocationValidator : AbstractValidator<CompanyLocationDTO>
    {
        public CompanyLocationValidator()
        {
            RuleFor(x => x.Country)
               .NotEmpty().WithMessage("Country is required.")
               .MaximumLength(100).WithMessage("Country cannot exceed 100 characters.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.")
                .MaximumLength(100).WithMessage("City cannot exceed 100 characters.");

            RuleFor(x => x.District)
                .NotEmpty().WithMessage("District is required.")
                .MaximumLength(100).WithMessage("District cannot exceed 100 characters.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(200).WithMessage("Address cannot exceed 200 characters.");

            RuleFor(x => x.ZipCode)
                .NotEmpty().WithMessage("Zip code is required.")
                .Matches(@"^\d{4,10}$").WithMessage("Zip code must be between 4 and 10 digits.");
        }
    }

    public class CompanyRegisterCommandValidator : AbstractValidator<CompanyRegisterCommand>
    {
        public CompanyRegisterCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Company name is required.")
                .Length(2, 100).WithMessage("Company name must be between 2 and 100 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email must be a valid email address.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"\d").WithMessage("Password must contain at least one digit.")
                .Matches(@"[^\da-zA-Z]").WithMessage("Password must contain at least one special character.");

            RuleFor(x => x.Hotline)
                .NotEmpty().WithMessage("Hotline is required.")
                .Matches(@"^\+?[0-9]{7,15}$").WithMessage("Hotline must be a valid phone number (7–15 digits, optional leading '+').");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(x => x.Locations)
                .NotEmpty().WithMessage("At least one company location is required.")
                .Must(locs => locs != null && locs.Any())
                    .WithMessage("You must specify at least one location.")
                .ForEach(locRule =>
                    locRule.SetValidator(new CompanyLocationValidator())
                );
        }
    }
}
