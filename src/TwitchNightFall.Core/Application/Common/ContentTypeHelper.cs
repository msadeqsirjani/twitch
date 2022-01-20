namespace TwitchNightFall.Core.Application.Common;

public class ContentTypeHelper
{
    public static string GetContentType(string filename)
    {
        var fileExtension = Path.GetExtension(filename).ToLower();

        return fileExtension switch
        {
            ".jpg" => "image/jpg",
            ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".gif" => "image/gif",
            ".bmp" => "image/bmp",
            _ => "application/octet-stream"
        };
    }
}