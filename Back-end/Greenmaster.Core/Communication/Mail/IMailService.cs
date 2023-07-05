using Greenmaster.Core.Models.Users;
using StaticData.Communication.Mail;

namespace Greenmaster.Core.Communication.Mail;

public interface IMailService
{
    void SendAsync(string title, MailType type, User user);
    void SendAsync(string title, MailType type, string from, User user);
    void SendAsync(string title, MailType type, string from, User user, string cc);
    void SendAsync(string title, MailType type, string from, User user, string cc, string bcc);
}