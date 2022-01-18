namespace TwitchNightFall.Core.Application.Exceptions;

public class MessageException : Exception
{
    public MessageException()
    {
        
    }

    public MessageException(string message) : base(message)
    {
        
    }
}