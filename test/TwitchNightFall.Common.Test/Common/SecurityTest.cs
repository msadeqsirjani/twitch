using FluentAssertions;
using TwitchNightFall.Common.Common;
using Xunit;

namespace TwitchNightFall.Common.Test.Common;

public class SecurityTest 
{
    [Theory]
    [InlineData("28030B03-D3D4-4569-987F-1F168BCF1764")]
    [InlineData("FC88120D-F7EA-44F0-A97D-08E7A95AE91D")]
    [InlineData("EE1CF269-C170-4856-97D6-0323FE621BBF")]
    [InlineData("FB695CC6-5B63-447B-986D-BA890CAA99DD")]
    public void Encrypt_CheckReturnEncryptedString(string text)
    {
        var encryption = Security.Encrypt(text);

        encryption.Should().NotBeNullOrEmpty();
        encryption.Should().NotBeNullOrWhiteSpace();
        encryption.Should().BeEquivalentTo(Security.Encrypt(text));
    }

    [Theory]
    [InlineData("28030B03-D3D4-4569-987F-1F168BCF1764")]
    [InlineData("FC88120D-F7EA-44F0-A97D-08E7A95AE91D")]
    [InlineData("EE1CF269-C170-4856-97D6-0323FE621BBF")]
    [InlineData("FB695CC6-5B63-447B-986D-BA890CAA99DD")]
    public void Decrypt_CheckInputAndOutputIsTheSame(string text)
    {
        var encryption = Security.Encrypt(text);

        var decryption = Security.Decrypt(encryption);

        decryption.Should().NotBeNullOrEmpty();
        decryption.Should().NotBeNullOrWhiteSpace();
        decryption.Should().Be(text);
    }
}