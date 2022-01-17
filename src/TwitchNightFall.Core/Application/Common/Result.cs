namespace TwitchNightFall.Core.Application.Common;

public enum ResultMode : byte
{
    Exception,
    Message,
    Success
}

public class Result
{
    public Result(ResultMode resultMode, dynamic? value, string? message)
    {
        ResultMode = resultMode;
        Value = value;
        Message = message;
    }

    public ResultMode ResultMode { get; }
    public dynamic? Value { get; }
    public string? Message { get; }

    public static Result WithSuccess() => new(ResultMode.Success, null, null);
    public static Result WithSuccess(dynamic value) => new(ResultMode.Success, value, null);
    public static Result WithMessage(string message) => new(ResultMode.Message, null, message);
    public static Result WithException() => new(ResultMode.Exception, null, null);
    public static Result WithException(string message) => new(ResultMode.Exception, null, message);
}