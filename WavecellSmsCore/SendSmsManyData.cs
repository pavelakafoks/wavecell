using System.Collections.Generic;

namespace WavecellSmsCore
{
    public class SendSmsManyData
    {
        public SendSmsManyData(
            IList<SendSmsSingleRequest> messages
            , string apiKey
            , string url
            , string subAccountId
            )
        {
            ApiKey = apiKey;
            Url = url;
            SubAccountId = subAccountId;
            SendSmsManyRequest = new SendSmsManyRequest
            {
                Messages = messages
            };
        }

        public SendSmsManyRequest SendSmsManyRequest { get; set; }

        public string SubAccountId { get; set; }

        public string ApiKey { get; set; }    // for AuthenticationMode.ApiKeyBearerToken

        private string _url;
        public string Url {
            get => _url.Replace("{subAccountId}", SubAccountId);
            set => _url = value;
        }
    }
}