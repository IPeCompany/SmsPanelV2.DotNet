namespace IPE.SmsIr.Models.Results
{
    public class MessageReportResult
    {
        public int MessageId { get; }
        public long Mobile { get; }
        public string MessageText { get; }
        public int SendDateTime { get; }
        public long LineNumber { get; }
        public decimal Cost { get; }
        public byte? DeliveryState { get; }
        public int? DeliveryDateTime { get; }
    }
}