using Greenmaster.Core.Models.Users;

namespace Greenmaster.Core.Communication.Mail
{
    public class ConfirmationMail : MailBase
    {
        private const string FileName = "confirmation-mail.html";
        private const string Url = "http://localhost:4200/add-password";

        public ConfirmationMail(string fromAddress, User user) : base(fromAddress, user)
        {

        }

        protected override string CreateMailBody()
        {
            return InsertData(GetMail(FileName));
        }

        public override string InsertData(string html)
        {
            html = html.Replace("{{first_name}}", User.FirstName)
                .Replace("{{Sender_Name}}", $"{User.FirstName} {User.LastName}")
                .Replace("{{link}}", $"{Url}?email={User.Email}&token={User.ResetToken}");
            return html;
        }

    }
}
