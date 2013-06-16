using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace DisasterReliefHub.Libraries
{
    public class SendGrid
    {
        private string Account { get; set; }
        private string Password { get; set; }
        public SendGrid(string account, string password)
        {
            Account = account;
            Password = password;

        }

        public void Send(string emailAddress, string name,string subject, string htmlBody, string textBody)
        {
            try
            {
                MailMessage mailMsg = new MailMessage();

                // To
                mailMsg.To.Add(new MailAddress(emailAddress, name));

                // From
                mailMsg.From = new MailAddress("disasterhub@cloudapp.net", "Disaster Relief Hub");

                // Subject and multipart/alternative Body
                mailMsg.Subject = subject;
                string text = textBody;
                string html = htmlBody;
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                // Init SmtpClient and send
                SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
                System.Net.NetworkCredential credentials = new NetworkCredential(Account, Password);
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
