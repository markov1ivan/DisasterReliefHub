using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Autofac;

using DisasterReliefHub.Domain.Models;
using DisasterReliefHub.Domain.Repository;
using DisasterReliefHub.Utilities;
using DisasterReliefHub.Utilities.Json;
using DisasterReliefHub.Utilities.Json.Handlers;

using Newtonsoft.Json.Linq;

namespace DisasterReliefHub.App_Start
{
    public class DataEvents
    {
        public static void Setup()
        {
            JsonHttpHandler.RegisterAction("PostPeople", delegate(JObject data)
                {
                    var result = new JsonResult();
                    var array = JArray.Parse(data["data"].ToString());
                    var repo = DependencyInjection.Container.Resolve<IRepository>();
                    foreach (JToken jToken in array)
                    {
                        SafePerson person = new SafePerson();
                        person.FirstName = jToken["first_name"].Value<string>();
                        person.LastName = jToken["last_name"].Value<string>();
                        person.Email = jToken["email"].Value<string>();
                        person.Latitude = jToken["lat"].Value<string>();
                        person.Longitude = jToken["lng"].Value<string>();
                        person.Message = jToken["message"].Value<string>();
                        person.City = jToken["city"].Value<string>();
                        person.State = jToken["state"].Value<string>();
                        person.Country = jToken["country"].Value<string>();

                        try
                        {
                            repo.Save<SafePerson>(person);
                        }
                        catch (Exception ex)
                        {

                            repo.Save<Error>(new Error() { Message = ex.Message, Details = ex.ToString() });
                        }
                    }
                    result.Success = true;
                    NotificationTimer.SendNotifications();
                    return result;
                });
        }
    }
}
