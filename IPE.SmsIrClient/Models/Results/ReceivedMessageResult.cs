namespace IPE.SmsIrClient.Models.Results
{
    public class ReceivedMessageResult
    {
        public string MessageText { get; }
        public long Number { get; }
        public long Mobile { get; }
        public int ReceivedDateTime { get; }
    }
}