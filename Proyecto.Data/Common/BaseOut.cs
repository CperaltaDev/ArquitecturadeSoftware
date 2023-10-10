
using System.Net;

namespace Proyecto.Data.Common
{
    public class BaseOut
    {
        public Result result { get; set; }
        public string message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
