namespace IPE.SmsIr.Models.Requests
{
    internal class LikeToLikeSendRequest
    {
        internal LikeToLikeSendRequest(long lineNumber, string[] messageTexts, string[] mobiles, int? sendDateTime)
        {
            LineNumber = lineNumber;
            MessageTexts = messageTexts;
            Mobiles = mobiles;
            SendDateTime = sendDateTime;
        }

        internal long LineNumber { get; set; }
        internal string[] MessageTexts { get; set; }
        internal string[] Mobiles { get; set; }
        internal int? SendDateTime { get; set; }
    }
}