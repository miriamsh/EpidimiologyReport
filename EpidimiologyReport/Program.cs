using EpidimiologyReport;
using EpidimiologyReport.Api.Controllers;
using EpidimiologyReport.Services;
using EpidimiologyReport.Dal;
using Serilog;
using Serilog.Events;
using Serilog.Templates;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using EpidimiologyReport.Dal.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();

builder.Services.AddDbContext<ReportingContext>(options =>
options.UseSqlServer("Server=LAPTOP-PM9O5HJ5;Database=Reporting;Trusted_Connection=True;"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    // Filter out ASP.NET Core infrastructre logs that are Information and below
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    //.WriteTo.Console()
    .WriteTo.File(new ExpressionTemplate(
          "[{@t:HH:mm:ss} {@l:u3} {SourceContext}] {@m}\n{@x}"),"C:/Users/מירי/source/repos/EpidimiologyReport/log.txt"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

//app.UseExceptionHandler(c => c.Run(async context =>
//{
//    var exception = context.Features
//        .Get<IExceptionHandlerPathFeature>()
//        .Error;
//    var response = new { error = exception.Message };
//    await context.Response.WriteAsJsonAsync(response);
//}));

app.UseErrorLogging();

app.UseHttpLogging();

app.MapControllers();

app.Run();

public partial class Program { }

