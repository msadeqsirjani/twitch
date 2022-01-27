using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Core.Application.Exceptions;
using TwitchNightFall.Core.Application.ViewModels;
using TwitchNightFall.Domain.Entities;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace TwitchNightFall.Core.Application.Services;

public interface IMailService
{
    Task Send(string email, CancellationToken cancellationToken = new());
}

public class MailService : IMailService
{
    private readonly MailSetting _mailSetting;
    private readonly IWebHostEnvironment _environment;
    private readonly OtpSetting _otpSetting;
    private readonly IResetPasswordService _resetPasswordService;

    public MailService(IOptions<MailSetting> mailSetting, IWebHostEnvironment environment, IOptions<OtpSetting> otpSetting, IResetPasswordService resetPasswordService)
    {
        _mailSetting = mailSetting.Value;
        _environment = environment;
        _resetPasswordService = resetPasswordService;
        _otpSetting = otpSetting.Value;
    }

    public async Task Send(string email, CancellationToken cancellationToken = new())
    {
        if (!email.IsValidEmail())
            throw new MessageException("پست الکترونیکی معتبر نمی باشد");

        MimeMessage message = new();

        MailboxAddress from = new("Twitch Night Fall", _mailSetting.Email);
        message.From.Add(from);

        MailboxAddress to = new(email, email);
        message.To.Add(to);

        message.Subject = "Your single-use code";

        var singleUseCode = RandomCodeGenerator.GenerateRandomCode(_otpSetting.Length, _otpSetting.PermittedLetters);

        BodyBuilder builder = new()
        {
            HtmlBody = string.Format(
                await File.ReadAllTextAsync(Path.Combine(_environment.WebRootPath, "reset_password.html"),
                    cancellationToken), email, singleUseCode),
        };

        message.Body = builder.ToMessageBody();

        using SmtpClient client = new();
        await client.ConnectAsync(_mailSetting.MailServerAddress, _mailSetting.MailServerPort, SecureSocketOptions.StartTls, cancellationToken);
        await client.AuthenticateAsync(_mailSetting.Email, _mailSetting.Password, cancellationToken);
        await client.SendAsync(message, cancellationToken);
        await client.DisconnectAsync(true, cancellationToken);

        await _resetPasswordService.InsertAsync(new ResetPassword(email, singleUseCode), cancellationToken);
    }
}