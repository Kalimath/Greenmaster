using Greenmaster.Core.Models.Users;
using SendGrid.Helpers.Mail;

namespace Greenmaster.Core.Communication.Mail;

public abstract class MailBase
{
    public string FromAddress { get; set; }
    public User User { get; set; }
    public string Mailbody { get; private set; }
    public MailBase(string fromAddress, User user)
    {
        FromAddress = fromAddress;
        User = user;
        Mailbody = CreateMailBody(); 
    }

    protected abstract string CreateMailBody();
    public abstract string InsertData(string html);


    public SendGridMessage CreateMail(string title)
    {
        var fromAddress = new EmailAddress(FromAddress);
        var toAddress = new EmailAddress() { Email = User.Email, Name = User.FirstName + " " + User.LastName };
        var htmlMessage = Mailbody;
        var message = htmlMessage.Replace("<br/>","\n");
        var msg = MailHelper.CreateSingleEmailToMultipleRecipients(fromAddress, new List<EmailAddress>() { toAddress, new ("info@greenmaster.be") }, title, message, htmlMessage);
        return msg;
    }

    public string GetMail(string filename)
    {
        var path = Path.Combine(Environment.CurrentDirectory, @"..\Greenmaster.Core\Communication\Mail\Html_Templates\confirmation-mail.html", filename);
        var html = File.ReadAllText(path);
        return html;
    }
}