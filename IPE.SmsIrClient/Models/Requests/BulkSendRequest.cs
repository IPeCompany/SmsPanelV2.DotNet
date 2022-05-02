namespace IPE.SmsIrClient.Models.Requests
{
    internal class BulkSendRequest
    {
        internal BulkSendRequest(long lineNumber, string messageText, string[] mobiles, int? sendDateTime)
        {
            LineNumber = lineNumber;
            MessageText = messageText;
            Mobiles = mobiles;
            SendDateTime = sendDateTime;
        }

        internal long LineNumber { get; set; }
        internal string MessageText { get; set; }
        internal string[] Mobiles { get; set; }
        internal int? SendDateTime { get; set; }
    }
}