namespace IPE.SmsIrClient.Models.Results
{
    public class ReceivedMessageResult
    {
        public string MessageText { get; set; }
        public long Number { get; set; }
        public long Mobile { get; set; }
        public int ReceivedDateTime { get; set; }
    }
}