using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace TwitchNightFall.Core.Application.Services
{
    public interface ILogService
    {
        void LogError(Exception exception);
        void LogError(string message);
        void LogFatal(Exception exception);
        void LogFatal(string message);
        void LogInfo(string message);
    }

    public class LogService : ILogService
    {
        private readonly ILogger _logger = Log.ForContext<LogService>();

        public void LogError(Exception exception)
        {
            _logger.Error(exception, exception.Message);
        }

        public void LogError(string message)
        {
            _logger.Error(message);
        }

        public void LogFatal(Exception exception)
        {
            _logger.Fatal(exception, exception.Message);
        }

        public void LogFatal(string message)
        {
            _logger.Fatal(message);
        }

        public void LogInfo(string message)
        {
            _logger.Information(message);
        }
    }
}
