using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobPortal.Application.Common.DTOs;
using JobPortal.Application.Common.Interfaces;
using JobPortal.Domain.Entities;
using MediatR;

namespace JobPortal.Application.Companies.Commands.Register
{
    public class CompanyRegisterCommandHandler : IRequestHandler<CompanyRegisterCommand, CommonResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CompanyRegisterCommandValidator _validator;

        public CompanyRegisterCommandHandler(IUnitOfWork unitOfWork, CompanyRegisterCommandValidator validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<CommonResult> Handle(CompanyRegisterCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return new CommonResult
                {
                    IsSucceed = false,
                    Message = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))
                };
            }

            var isEmailExists = await _unitOfWork.Accounts.IsEmailExistsAsync(request.Email, cancellationToken);
            if (isEmailExists)
            {
                return new CommonResult
                {
                    IsSucceed = false,
                    Message = "Email already exists."
                };
            }

            var account = new Account
            {
                Email = request.Email,
                PasswordHash = request.Password,
                Role = Domain.Enums.UserRole.Company,

            };
            await _unitOfWork.Accounts.AddAsync(account, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            var company = new Company
            {
                Name = request.Name,
                Hotline = request.Hotline,
                Description = request.Description,
                Industry = request.Industry,
                WebsiteUrl = request.WebsiteUrl,
                Locations = request.Locations.Select(location => new CompanyLocation
                {
                    Country = location.Country,
                    City = location.City,
                    District = location.District,
                    Address = location.Address,
                    ZipCode = location.ZipCode
                }).ToList(),
                AccountId = account.Id
            };
            await _unitOfWork.Companies.AddAsync(company, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            return new CommonResult
            {
                IsSucceed = true,
                Message = "Company registered successfully."
            };
        }
    }
}
