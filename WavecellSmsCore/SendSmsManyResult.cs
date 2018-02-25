using System.Collections.Generic;   

namespace WavecellSmsCore
{
    public sealed class SendSmsManyResult
    {
        public string BatchId { get; set; }
        public string ClientBatchId { get; set; }
        public string AcceptedCount { get; set; }
        public string RejectedCount { get; set; }
        public List<SendSmsSingleResult> Messages { get; set; }
    }
}