namespace WavecellSmsCore
{
    public class SendSmsSingleData
    {
        public SendSmsSingleData(
            SendSmsSingleRequest sendSmsSingleRequest
            , string apiKey
            , string url
            , string subAccountId)
        {
            SendSmsSingleRequest = new SendSmsSingleRequest{
                Source = sendSmsSingleRequest.Source,
                Destination = sendSmsSingleRequest.Destination,
                ClientMessageId = sendSmsSingleRequest.ClientMessageId,
                DlrCallbackUrl = sendSmsSingleRequest.DlrCallbackUrl,
                Text = sendSmsSingleRequest.Text
            };
            ApiKey = apiKey;
            Url = url;
            SubAccountId = subAccountId;
        }

        public SendSmsSingleRequest SendSmsSingleRequest { get; set; }

        public string SubAccountId { get; set; }

        public string ApiKey { get; set; }

        private string _url;
        public string Url {
            get => _url.Replace("{subAccountId}", SubAccountId);
            set => _url = value;
        }
    }
}