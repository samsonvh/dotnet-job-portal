using Carter;
using FluentValidation;
using JobPortal.Application;
using JobPortal.Infrastructure;
using JobPortal.Infrastructure.Persistence;
using JobPortal.WebAPI;
using JobPortal.WebAPI.Middlewares;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationDependencies();
builder.Services.AddInfrastructureDependencies();
builder.Services.AddPersistenceDependencies(builder.Configuration);

builder.Services.AddCarter();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

foreach (var serviceDescriptor in builder.Services
    .Where(sd => sd.ServiceType.IsGenericType
        && sd.ServiceType.GetGenericTypeDefinition() == typeof(IValidator<>)))
{
    Console.WriteLine($"Validator: {serviceDescriptor.ImplementationType?.Name} - Lifetime: {serviceDescriptor.Lifetime}");
}

builder.Host.UseDefaultServiceProvider((context, options) =>
{
    options.ValidateScopes = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapCarter();

app.MapControllers();

app.Run();
