using Newtonsoft.Json;
using System.Collections.Generic;

namespace WavecellSmsCore
{
    public class SendSmsManyRequest
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string clientBatchId { get; set; }

        public IList<SendSmsSingleRequest> Messages { get; set; }
    }
}
