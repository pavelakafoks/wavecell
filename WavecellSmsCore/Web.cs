using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WavecellSmsCore
{
    public sealed class Web
    {
        public static async Task<string> PostRequest(string url, string body, string key)
        {
            string responseText;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer {apiKey}".Replace("{apiKey}", key));
                client.BaseAddress = new Uri(url);
                var response = await client.PostAsync(url, new  StringContent(body,
                                                                Encoding.UTF8, 
                                                                "application/json"));
                responseText = await response.Content.ReadAsStringAsync();
#if DEBUG
                Debug.WriteLine("Post request response: " + responseText);
#endif
            }
            return responseText;
        }
    }
}
