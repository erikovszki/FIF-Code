using FIF.Domain.Entities;
using FIF.Infrastructure;
using FIF.Persistence.Extensions;
using FIF.Registration.Middlewares;
using FIF.Registration.Models;
using FIF.Registration.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

// register all services what we made
builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddCommunAppServices();

// Register the validators
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly, includeInternalTypes: true);
builder.Services.AddFluentValidationAutoValidation(config =>
{
    config.DisableDataAnnotationsValidation = true;
});
//Register the global exception middleware
builder.Services.AddTransient<GlobalExceptionMiddleware>();

builder.Services.AddAutoMapper(typeof(ServiceRegistration).Assembly, typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// setup for the GlobalExceptionMiddleware
app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.ApplyMigrations();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
