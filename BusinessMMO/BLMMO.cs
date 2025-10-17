using System.Collections.Generic;
using ClassLibrary1;
using DataLayer;
using DataMMO;
using DataMMO.DataLayer;
using BusinessMMO;
using CommonMMO; // For me to use Emailinfo and EmailService

namespace Business_Logic
{
    public class BLMMO
    {
        private readonly DLMMO data = new DLMMO();
        private readonly DBMillionaireOrg db = new DBMillionaireOrg();
        private readonly EmailService emailService = new EmailService();

        public bool Register(string name) => data.Register(name);
        public bool Exit(string name) => data.Exit(name);
        public Guest Search(string name) => data.Search(name);
        public bool Exists(string name) => data.Exists(name);
        public List<Guest> AllGuests() => data.GetAll();

        //ALSO IF THE NOTIFICATION IS TO BE SENT THIS METHOD WILL HELP TO SEND THE NOTIFICATION PO //
        public bool SendNotification(string senderName, string recipientEmail, string subject, string body)
        {
            var info = new EmailInfo
            {
                To = recipientEmail,
                Subject = subject,
                Body = body
            };


            return emailService.SendEmail(senderName, info);
        }
    }
}
