namespace WavecellSmsCore
{
    public sealed class SendSmsSingleResultStatus
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public sealed class SendSmsSingleResult
    {
        public string Umid { get; set; }
        public string ClientMessageId { get; set; }
        public string Destination { get; set; }
        public string Encoding { get; set; }
        public SendSmsSingleResultStatus Status { get; set; }
    }
}