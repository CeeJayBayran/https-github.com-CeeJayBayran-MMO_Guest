using System.Net;
using System.Net.Mail;
using CommonMMO;
using DataLayer;

namespace BusinessMMO
{
    public class EmailService
    {
        private const string SmtpServer = "sandbox.smtp.mailtrap.io";
        private const int Port = 2525;
        private const string Username = "262e97ab352877";
        private const string Password = "217f84e9815e8a";
        private const string From = "from@example.com";

        private readonly InMemoryService inMemory = new();

        public bool SendEmail(string senderName, EmailInfo info)
        {
            if (!inMemory.Exists(senderName))
                return false;

            using (var client = new SmtpClient(SmtpServer, Port))
            {
                client.Credentials = new NetworkCredential(Username, Password);
                client.EnableSsl = true;
                client.Send(From, info.To, info.Subject, info.Body);
            }

            return true;
        }
    }
}
