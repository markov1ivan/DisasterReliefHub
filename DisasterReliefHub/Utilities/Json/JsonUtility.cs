using System.IO;
using System.Web;

using Newtonsoft.Json.Linq;

namespace DisasterReliefHub.Utilities.Json
{
    public class JsonUtility
  {
    /// <summary>
    /// Returns a parsed json object.
    /// If the request was made with the GET verb, the method assumes that the json payload is in the first query string parameter.
    /// </summary>
    /// <param name="request">http request instance</param>
    /// <returns>linq json object</returns>
    public static JObject GetJsonObjectFromRequest(HttpRequestBase request)
    {
      string json = GetJsonData(request);

      JObject jsonObject = new JObject();
      try
      {
        jsonObject = JObject.Parse(json);
      }catch { }

      return jsonObject;
    }

    /// <summary>
    /// Returns the json string object, send through the request
    /// If the request was made with the GET verb, the method assumes that the json payload is in the first query string parameter. 
    /// </summary>
    /// <param name="request">http request</param>
    /// <returns></returns>
    public static string GetJsonData(HttpRequestBase request)
    {
      string json = string.Empty;
      if (request.RequestType == "POST")
      {
        using (var reader = new StreamReader(request.InputStream))
        {
          json = reader.ReadToEnd();
        }
      }
      else
      {
        // The json data is stored in the query string
        // Get the action and the json data payload
        if (!string.IsNullOrEmpty(request.QueryString[0]))
        {
          json = request.QueryString[0];
        }
      }
      return json;
    }

    /// <summary>
    /// Returns a parsed json object.
    /// If the request was made with the GET verb, the method assumes that the json payload is in the first query string parameter.
    /// </summary>
    /// <param name="request">http request instance</param>
    /// <returns>concrete class wrapper for the json object</returns>
    public static T GetJsonObjectFromRequest<T>(HttpRequestBase request)
    {
      string json = GetJsonData(request);

      JObject jsonObject = null;
            try
      {
        jsonObject = JObject.Parse(json);
      }catch { jsonObject = null; }
      T result = default(T);

      if (jsonObject != null)
      {
        result = jsonObject.ToObject<T>();
      }
      return result;
    }
  }
}
