using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Core.Application.Exceptions;
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

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 200;


        switch (exception)
        {
            case MessageException messageException:
                return context.Response.WriteAsync(JsonConvert.SerializeObject(Result.WithException(messageException.Message)));
            case UnAuthorizedException unAuthorizedException:
                {
                    context.Response.StatusCode = 401;

                    return context.Response.WriteAsync(
                        JsonConvert.SerializeObject(Result.WithException(unAuthorizedException.Message)));
                }
            default:
                _logService.LogError(exception);

                return context.Response.WriteAsync(_environment.IsDevelopment()
                    ? JsonConvert.SerializeObject(Result.WithException(exception))
                    : JsonConvert.SerializeObject(Result.WithException(Statement.Failure)));
        }
    }
}