using System;

namespace IPE.SmsIrClient.Models.Results
{
    public class SendResult
    {
        public Guid PackId { get; set; }
        public int?[] MessageIds { get; set; }
        public decimal Cost { get; set; }
    }
}