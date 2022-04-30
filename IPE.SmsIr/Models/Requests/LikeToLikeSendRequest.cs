namespace IPE.SmsIr.Models.Requests
{
    public class LikeToLikeSendRequest
    {
        public LikeToLikeSendRequest(long lineNumber, string[] messageTexts, string[] mobiles, int? sendDateTime)
        {
            LineNumber = lineNumber;
            MessageTexts = messageTexts;
            Mobiles = mobiles;
            SendDateTime = sendDateTime;
        }

        public long LineNumber { get; set; }
        public string[] MessageTexts { get; set; }
        public string[] Mobiles { get; set; }
        public int? SendDateTime { get; set; }
    }
}