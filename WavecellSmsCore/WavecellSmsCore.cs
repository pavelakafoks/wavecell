using System;

namespace WavecellSmsCore
{
    public static class WavecellSmsCore
    {
        public static SendSmsSingleResult SendSmsSingle(SendSmsSingleData smsSingleData)
        {
            if (string.IsNullOrEmpty(smsSingleData.ApiKey))
            {
                throw new ArgumentNullException("ApiKey is required parameter");
            }
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(smsSingleData.SendSmsSingleRequest);
            var response = Web.PostRequest(smsSingleData.Url, body, smsSingleData.ApiKey);

            if (string.IsNullOrEmpty(response))
            {
                throw new Exception("Empty result of http request");
            }

            var toRet = Newtonsoft.Json.JsonConvert.DeserializeObject<SendSmsSingleResult>(response);
            return toRet;
        }


        public static SendSmsManyResult SendSmsMany(SendSmsManyData smsManyData)
        {
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(smsManyData.SendSmsManyRequest);
            var response = Web.PostRequest(smsManyData.Url, body, smsManyData.ApiKey);

            if (string.IsNullOrEmpty(response))
            {
                throw new Exception("Empty result of http request");
            }

            var toRet = Newtonsoft.Json.JsonConvert.DeserializeObject<SendSmsManyResult>(response);
            return toRet;
        }
    }
}
