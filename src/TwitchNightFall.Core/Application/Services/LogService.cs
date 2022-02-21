using Serilog;

namespace TwitchNightFall.Core.Application.Services;

public interface ILogService
{
    void LogError(Exception exception);
}

public class LogService : ILogService
{
    private readonly ILogger _logger = Log.ForContext<LogService>();

    public void LogError(Exception exception)
    {
        _logger.Error(exception, exception.Message);
    }
}