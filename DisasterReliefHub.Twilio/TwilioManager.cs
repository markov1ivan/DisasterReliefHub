using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Twilio;

namespace DisasterReliefHub.Twilio
{
    public class TwilioManager
    {
        private string ApiKey { get; set; }
        private string ApiSecret { get; set; }

        public TwilioManager(string apiKey, string secret)
        {
            ApiSecret = secret;
            ApiKey = apiKey;
        }

        public void SetSms(string from, string to, string message)
        {
            TwilioRestClient client = new TwilioRestClient(ApiKey, ApiSecret);
            client.SendSmsMessage(from, to, message);
        }
    }
}
