using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Core.Application.Services;

namespace TwitchNightFall.Core.Infra.IoC.MiddleWares;

public class ExceptionHandler
{
    private readonly RequestDelegate _next;
    private readonly ILogService _logService;
    private readonly IWebHostEnvironment _environment;

    public ExceptionHandler(RequestDelegate next, ILogService logService, IWebHostEnvironment environment)
    {
        _next = next;
        _logService = logService;
        _environment = environment;
    }

    public Task Invoke(HttpContext context)
    {
        try
        {
            return _next(context);
        }
        catch (Exception exception)
        {
            return HandleExceptionAsync(context, exception, _environment);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception, IWebHostEnvironment env)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 200;

        _logService.LogError(exception);

        return context.Response.WriteAsync(_environment.IsDevelopment()
            ? JsonConvert.SerializeObject(Result.WithException(exception))
            : JsonConvert.SerializeObject(Result.WithException(Statement.Failure)));
    }
}