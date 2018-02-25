using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace WavecellSmsCore
{
    public sealed class Web
    {
        public static string PostRequest(string url, string body, string key)
        {
            string responseText;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 20000; // 20 seconds
            request.Method = "POST";
            request.ContentType = "application/json";

            byte[] data = Encoding.UTF8.GetBytes(body);
            request.ContentLength = data.Length;

            if (!string.IsNullOrEmpty(key))
            {
                request.Headers.Add("Authorization", "Bearer {apiKey}".Replace("{apiKey}", key));
            }

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(data, 0, data.Length);
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var dataStream = response.GetResponseStream())
            using (var reader = new StreamReader(dataStream ?? throw new InvalidOperationException("Response is empty")))
            {
                responseText = reader.ReadToEnd();
#if DEBUG
                Debug.WriteLine("Post request response: " + responseText);
#endif
            }

            return responseText;
        }
    }
}
