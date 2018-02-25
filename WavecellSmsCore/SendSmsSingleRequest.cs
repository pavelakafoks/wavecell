using Newtonsoft.Json;

namespace WavecellSmsCore
{
    public class SendSmsSingleRequest
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ClientMessageId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DlrCallbackUrl { get; set; }

        public string Source { get; set; }
        public string Text { get; set; }

        private string _destination;
        public string Destination
        {
            get
            {
                if (_destination.StartsWith("+"))
                {
                    _destination = _destination.Substring(1);
                }
                return _destination;
            }
            set => _destination = value;
        }
    }
}
