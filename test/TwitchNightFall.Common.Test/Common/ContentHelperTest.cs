using FluentAssertions;
using TwitchNightFall.Common.Common;
using Xunit;

namespace TwitchNightFall.Common.Test.Common;

public class ContentHelperTest
{
    [Theory]
    [InlineData("F59307ED-20F5-4A88-9D60-D9F31E4AC6E6.jpg", "image/jpg")]
    [InlineData("F59307ED-20F5-4A88-9D60-D9F31E4AC6E6.jpeg", "image/jpeg")]
    [InlineData("F59307ED-20F5-4A88-9D60-D9F31E4AC6E6.png", "image/png")]
    [InlineData("F59307ED-20F5-4A88-9D60-D9F31E4AC6E6.gif", "image/gif")]
    [InlineData("F59307ED-20F5-4A88-9D60-D9F31E4AC6E6.bmp", "image/bmp")]
    [InlineData("F59307ED-20F5-4A88-9D60-D9F31E4AC6E6.txt", "application/octet-stream")]
    [InlineData("F59307ED-20F5-4A88-9D60-D9F31E4AC6E6.exe", "application/octet-stream")]
    public void ToContentType_MultipleFilename_ReturnCorrectContentType(string filename, string expected)
    {
        ContentHelper.ToContentType(filename).Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData("F59307ED-20F5-4A88-9D60-D9F31E4AC6E6.jpg", "image/png")]
    [InlineData("F59307ED-20F5-4A88-9D60-D9F31E4AC6E6.jpeg", "image/gif")]
    [InlineData("F59307ED-20F5-4A88-9D60-D9F31E4AC6E6.png", "application/json")]
    [InlineData("F59307ED-20F5-4A88-9D60-D9F31E4AC6E6.gif", "text/plain")]
    [InlineData("F59307ED-20F5-4A88-9D60-D9F31E4AC6E6.bmp", "application/octet-stream")]
    [InlineData("F59307ED-20F5-4A88-9D60-D9F31E4AC6E6.txt", "text/plain")]
    [InlineData("F59307ED-20F5-4A88-9D60-D9F31E4AC6E6.exe", "application/xml")]
    public void ToContentType_MultipleFilename_ReturnInCorrectContentType(string filename, string expected)
    {
        ContentHelper.ToContentType(filename).Should().NotBeEquivalentTo(expected);
    }
}