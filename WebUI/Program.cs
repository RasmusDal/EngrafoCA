using Application;
using Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Serilog;
using WebUI.Middleware;

var builder = WebApplication.CreateBuilder(args);

//! Add services to the container.
builder.Services
	.AddApplication()
	.AddInfrastructure(builder.Configuration);

//! Logging
Log.Logger = new LoggerConfiguration()
	.ReadFrom.Configuration(builder.Configuration).CreateLogger();

builder.Services.AddSerilog();

//! API
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseMiddleware<RequestLogContextMiddleware>();
app.UseSerilogRequestLogging();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Home}/{id?}");

app.Run();
