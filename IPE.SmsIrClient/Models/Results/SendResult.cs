using System;

namespace IPE.SmsIrClient.Models.Results
{
    public class SendResult
    {
        public Guid PackId { get; }
        public int?[] MessageIds { get; }
        public decimal Cost { get; }
    }
}