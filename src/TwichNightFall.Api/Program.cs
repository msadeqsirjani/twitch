using System.Text;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using TwitchNightFall.Core.Infra.Data;
using TwitchNightFall.Core.Infra.IoC;


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, configuration) =>
{
    configuration.WriteTo.Console();
    configuration.WriteTo.File("Logs", LogEventLevel.Error, fileSizeLimitBytes: 10240,
        rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true, encoding: Encoding.UTF8);
});


builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    var context = app.Services.GetRequiredService<ApplicationDbContext>();

    context.Database.Migrate();
}

app.UseApplications(app.Environment);

app.Run();