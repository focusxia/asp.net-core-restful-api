using Newtonsoft.Json;

namespace DotnetRestFulWebApi.Helper
{
    public class ErrorDetail
    {
        public int StatusCode { get; set; }
        public string Massage { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}