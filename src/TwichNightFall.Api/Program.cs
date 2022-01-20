using System.Text;
using Serilog;
using Serilog.Events;
using TwitchNightFall.Core.Infra.IoC;


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, configuration) =>
{
    configuration.WriteTo.Console();
    configuration.WriteTo.File("Logs/log.txt", LogEventLevel.Error, fileSizeLimitBytes: 10240,
        rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true, encoding: Encoding.UTF8);
});


builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

app.UseApplications();

app.Run();