using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

using Newtonsoft.Json.Linq;

using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace DisasterReliefHub.Libraries
{
    public class Dwolla
    {
        private static string sendRequest = "https://www.dwolla.com/oauth/rest/transactions/guestsend";
        private string ClientId { get; set; }
        private string ClientSecret { get; set; }

        public Dwolla(string key, string secret)
        {
            ClientId = key;
            ClientSecret = secret;
        }


        public DwollaResponse Send(string recipient, string sender, double amount, string firstName, string lastName, string routing, string accountNumber, DwollaAccountType accountType, string notes)
        {
             HttpWebRequest request = (HttpWebRequest)HttpWebRequest
                 .Create(new Uri(sendRequest));
                request.Method = "POST";
                request.ContentType = "application/json";
                DwollaResponse dwollaResult = new DwollaResponse();
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                JObject json = new JObject();

                json["client_id"] = ClientId;
                json["client_secret"] = ClientSecret;
                json["destinationId"] = recipient;
                json["amount"] = amount;
                json["firstName"] = firstName;
                json["lastName"] = lastName;
                json["emailAddress"] = sender;
                json["routingNumber"] = routing;
                json["accountNumber"] = accountNumber;
                json["accountType"] = accountType.ToString();
                json["destinationType"] = "Email";
                json["notes"] = (notes ?? string.Empty).Substring(0, 250);
                string payload = json.ToString();
                streamWriter.Write(payload);
                streamWriter.Flush();
                streamWriter.Close();

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                   var jsonResult = streamReader.ReadToEnd();
                  JObject data = JObject.Parse(jsonResult);
                  dwollaResult.Success = data["Success"].Value<string>().ToLower() == "true";
                  dwollaResult.Message = data["Message"].Value<string>();
                  dwollaResult.Response = data["Response"].Value<string>();
                }
            }
            return dwollaResult;
        }
    }

    public class DwollaResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Response { get; set; }
    }
    public enum DwollaAccountType
    {
        Checking = 0,
        Savings
    }
}
