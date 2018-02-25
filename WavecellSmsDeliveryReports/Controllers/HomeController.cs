using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace WavecellSmsDeliveryReports.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet]
        public ContentResult Index()
        {
            var content = System.IO.File.ReadAllText("index.html");
            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = content
            };
        }
    }
}
