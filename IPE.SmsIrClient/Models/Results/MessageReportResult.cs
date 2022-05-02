namespace IPE.SmsIrClient.Models.Results
{
    public class MessageReportResult
    {
        public int MessageId { get; set; }
        public long Mobile { get; set; }
        public string MessageText { get; set; }
        public int SendDateTime { get; set; }
        public long LineNumber { get; set; }
        public decimal Cost { get; set; }
        public byte? DeliveryState { get; set; }
        public int? DeliveryDateTime { get; set; }
    }
}