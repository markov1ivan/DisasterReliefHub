using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;

using Autofac;

using DisasterReliefHub.App_Start;
using DisasterReliefHub.Domain;
using DisasterReliefHub.Domain.Models;
using DisasterReliefHub.Domain.Repository;
using DisasterReliefHub.Libraries;
using DisasterReliefHub.Twilio;

namespace DisasterReliefHub.Utilities
{
    public class NotificationTimer : IDisposable
    {
        private Timer timer = new Timer();

        public NotificationTimer()
        {
            timer.Interval = 5 * 60000;
            timer.Elapsed += ElapsedTimer;
            timer.Start();
        }

        private void ElapsedTimer(object sender, ElapsedEventArgs e)
        {
            SendNotifications();
        }

        public static void SendNotifications()
        {
            var repo = DependencyInjection.Container.Resolve<IRepository>();
            var twilio = DependencyInjection.Container.Resolve<TwilioManager>();
            var sendGrid = DependencyInjection.Container.Resolve<SendGrid>();
            var missingPeople = repo.Query<MissingPerson>().Where(p => !p.IsFound).ToList();
            var safePeople = repo.Query<SafePerson>().ToList();
            var users = repo.Query<User>().ToList();
            foreach (SafePerson safePerson in safePeople)
            {
                var found =
                    missingPeople.FirstOrDefault(
                        p =>
                        p.FirstName == safePerson.FirstName && p.LastName == safePerson.LastName
                        || p.Email == safePerson.Email);

                if (found != null)
                {
                    var relative = users.FirstOrDefault(u => u.Id == found.UserFk);
                    if (relative.SendEmailNotification)
                    {
                        var html =
                            "<p>We have found a person that matches the criteria you have specified.</p><p>Pleae login to Disaster Relief Hub and verify that is the person you are looking for.</p>";
                        sendGrid.Send(
                            relative.Email,
                            string.Empty,
                            "We have found a person you are looking for",
                            html,
                            string.Empty);
                    }

                    if (relative.SendPhoneNotification)
                    {
                        var text =
                            "We have found a persona that matches the criteria you have specified. Please login to Disaster Relief Hub and verify.";
                        var phone = relative.Phone.Replace("-", "");
                        twilio.SetSms("+18164795133", phone, text);
                    }

                    found.IsFound = true;
                    repo.Save(found);
                }
            }
        }

        public void Dispose()
        {
            timer.Dispose();
            timer = null;
        }
    }
}