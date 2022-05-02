namespace IPE.SmsIrClient.Models.Requests
{
    internal class BulkSendRequest
    {
        public BulkSendRequest(long lineNumber, string messageText, string[] mobiles, int? sendDateTime)
        {
            LineNumber = lineNumber;
            MessageText = messageText;
            Mobiles = mobiles;
            SendDateTime = sendDateTime;
        }

        public long LineNumber { get; set; }
        public string MessageText { get; set; }
        public string[] Mobiles { get; set; }
        public int? SendDateTime { get; set; }
    }
}