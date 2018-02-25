using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using WavecellSmsDeliveryReports.Models;

namespace WavecellSmsDeliveryReports.Controllers
{
    [Route("api/[controller]")]
    public class NotificationController : Controller
    {
        static MessagesMq MessagesMq = new MessagesMq();

        [HttpGet]
        public string Get()
        {
            var toRet = new StringBuilder();
            var messages = MessagesMq.Consume();
            if (messages != null)
            {
                foreach (var message in messages)
                {
                    toRet.Append("<pre>");
                    toRet.Append(message.Replace("<", "&lt;").Replace(">", "&gt;"));
                    toRet.Append("<pre/>");
                    toRet.Append("<br/>");
                    
                }
            }
            return toRet.ToString();
        }

        [HttpPost]
        public async Task<string> Post()
        {
            string content;
            try
            {
                content = await new StreamReader(Request.Body).ReadToEndAsync();
                var serializer = new XmlSerializer(typeof(DeliveryReport));
                using (var rdr = new StringReader(content))
                {
                    var deliveryReport = (DeliveryReport) serializer.Deserialize(rdr);

                    // now you can use the DeliveryReport object
                    MessagesMq.Add("OK: " + content);
                }
                return "OK";
            }
            catch (Exception exc)
            {
                MessagesMq.Add("ERROR: " + exc.Message + ", " + exc.StackTrace);
                return "ERROR";
            }
        }
    }
}
