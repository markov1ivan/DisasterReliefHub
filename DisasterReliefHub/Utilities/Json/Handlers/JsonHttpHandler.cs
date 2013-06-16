// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonHttpHandler.cs" company="Intouch Solutions, Inc">
//   Copyright © Intouch Solution 2012
// </copyright>
// <summary>
//   Json Http Handler.
//   Allows reg
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DisasterReliefHub.Utilities.Json.Handlers
{
    /// <summary>
  /// Json Http Handler.
  /// Allows registering events that can be called using jquery ajax calls
  /// expected format for passed json data {action : methodName, data : {method payload data }}
  /// when using http get, the json data is expected to be in the first query string parameter
  /// </summary>
  public class JsonHttpHandler : IHttpHandler
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="JsonHttpHandler"/> class.
    /// </summary>
    static JsonHttpHandler()
    {
      Actions = new Dictionary<string, Func<JObject, JsonResult>>();
    }

    /// <summary>
    /// Gets the actions.
    /// </summary>
    public static Dictionary<string, Func<JObject, JsonResult>> Actions { get; internal set; }

    /// <summary>
    /// Gets a value indicating whether is reusable.
    /// </summary>
    public bool IsReusable
    {
      get
      {
        return true;
      }
    }

    /// <summary>
    /// Register an action that can be called through an ajax javascript request to the server.
    /// This method will not overwrite existing events. To re-register an event, remove it first.
    /// </summary>
    /// <param name="name">
    /// Action name
    /// </param>
    /// <param name="action">
    /// Action event handle
    /// </param>
    public static void RegisterAction(string name, Func<JObject, JsonResult> action)
    {
      if (!string.IsNullOrEmpty(name) && !Actions.ContainsKey(name.ToLower()))
      {
        Actions.Add(name.ToLower(), action);
      }
    }

    /// <summary>
    /// Removes a registered action.
    /// </summary>
    /// <param name="name">
    /// Action name.
    /// </param>
    public static void RemoveAction(string name)
    {
      if (!string.IsNullOrEmpty(name) && Actions.ContainsKey(name.ToLower()))
      {
        Actions.Remove(name.ToLower());
      }
    }

    /// <summary>
    /// Going to handle json requests to the facebook application
    /// </summary>
    /// <param name="context">
    /// Http context
    /// </param>
    public void ProcessRequest(HttpContext context)
    {

      string jsonData = JsonUtility.GetJsonData(new HttpRequestWrapper(context.Request));
      string result = this.HandleJson(jsonData);
      context.Response.Write(result);
    }

    /// <summary>
    /// Handles json action/data sent to the server through a post
    /// </summary>
    /// <param name="json">
    /// json payload data
    /// </param>
    private string HandleJson(string json)
    {
      JObject jsonObject = JObject.Parse(json);
      JsonResult result = new JsonResult();
      if (!string.IsNullOrEmpty((string)jsonObject["action"]))
      {
        // Extract the payload data from the data wrapper
        var action = (string)jsonObject["action"];
        var jsonData = jsonObject["data"];

        if (Actions.ContainsKey(action.ToLower()))
        {
          Func<JObject, JsonResult> toExecute = Actions[action.ToLower()];
          if (toExecute != null)
          {

            try
            {
              result = toExecute.Invoke(JObject.Parse(jsonData.ToString()));
            }
            catch (Exception ex)
            {
              result.ErrorMessage = ex.ToString();
            }

          }
        }
      }
      string serializedResult = JsonConvert.SerializeObject(result);
      return serializedResult;
    }
  }
}