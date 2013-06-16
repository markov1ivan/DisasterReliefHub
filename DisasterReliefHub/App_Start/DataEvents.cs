using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

                    return result;
                });
        }
    }
}