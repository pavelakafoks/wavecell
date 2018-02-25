namespace WavecellSmsDeliveryReports
{
    public class DeliveryReport
    {
        public string UMID { get; set; }
        public string DateTimeStamp { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public string Source { get; set; }
        public string SubAccountId { get; set; }
        public string Attempt { get; set; }
        public string ErrorCode { get; set; }
        public string Destination { get; set; }
        public string Price { get; set; }
        public string Currency { get; set; }
        public string ClientMessageId { get; set; }
        public string Version { get; set; }
    }
}
