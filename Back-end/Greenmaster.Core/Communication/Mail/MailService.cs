using Greenmaster.Core.Models.Users;
using SendGrid;
using StaticData.Communication.Mail;
#pragma warning disable CS8625

namespace Greenmaster.Core.Communication.Mail;

public class MailService : IMailService
{
    private static MailService _mailService;
    private static string APIKEY;

    private MailService()
    {
    }
    public static MailService getInstance()
    {
        if (_mailService == null)
            _mailService = new MailService();
        return _mailService;
    }

    public static void SetKey(string key)
    {
        APIKEY = key;
    }
    public async void SendAsync(string title, MailType type, string from, User user)
    {
        SendAsync(title, type, from, user, null, null);
    }

    public async void SendAsync(string title, MailType type, string from, User user, string cc)
    {
        SendAsync(title, type, from, user, cc, null);
    }
    public void SendAsync(string title, MailType type, User user)
    {
        //gebruik enkel deze
        SendAsync(title, type, "simon.bettens@elmos.be", user, null, null);
    }

    public async void SendAsync(string title, MailType type, string from, User user, string cc, string bcc)
    {
        try
        {
            var client = new SendGridClient(APIKEY);
            MailBase mail = type switch
            {
                MailType.CONFIRMATION_MAIL => new ConfirmationMail(from, user),
                MailType.RESET_PASSWORD_MAIL => new ResetPasswordMail(from, user),
                _ => throw new ApplicationException("System error")
            };
            var response = await client.SendEmailAsync(mail.CreateMail(title)).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            var s = ex.Message;
        }
    }
}