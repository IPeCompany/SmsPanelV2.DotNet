using System;

namespace IPE.SmsIrClient.Models.Results
{
    public class PackResult
    {
        public Guid PackId { get; }

        public int RecipientCount { get; }

        public int CreationDateTime { get; }
    }
}