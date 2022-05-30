using EpidimiologyReport;
using EpidimiologyReport.Api.Controllers;
using EpidimiologyReport.Services;
using EpidimiologyReport.Dal;
using Serilog;
using Serilog.Events;
using Serilog.Templates;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    // Filter out ASP.NET Core infrastructre logs that are Information and below
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File(new ExpressionTemplate(
          "[{@t:HH:mm:ss} {@l:u3} {SourceContext}] {@m}\n{@x}"),"C:/Users/מירי/source/repos/EpidimiologyReport/log.txt"));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseHttpLogging();

app.MapControllers();



app.Run();

public partial class Program { }

