using Newtonsoft.Json;

namespace DisasterReliefHub.Utilities.Json
{
    public class JsonResult
  {
    public string ErrorMessage { get; set; }

    public object Data { get; set; }

    public bool Success { get; set; }

    public override string ToString()
    {

      return JsonConvert.SerializeObject(this);
    }
  }
}
