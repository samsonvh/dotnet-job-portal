using Carter;
using JobPortal.Application.Users.Applicant.Commands.Register;
using JobPortal.Application.Users.Company.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.WebAPI.Endpoints
{
    public class RegisterEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/register");

            group.MapPost("applicant", RegisterApplicant).WithName(nameof(RegisterApplicant));
            group.MapPost("company", RegisterCompany).WithName(nameof(RegisterCompany));
        }

        private static async Task<IResult> RegisterApplicant([FromBody] ApplicantRegisterCommand command, [FromServices] ISender sender)
        {
            await sender.Send(command);

            return Results.Ok();
        }
        private static async Task<IResult> RegisterCompany([FromBody] CompanyRegisterCommand command, [FromServices] ISender sender)
        {
            await sender.Send(command);

            return Results.Ok();
        }
    }
}
