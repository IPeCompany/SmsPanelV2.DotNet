using System;

namespace IPE.SmsIrClient.Exceptions
{
    public class SmsIrException : Exception
    {
        public readonly byte Status;

        internal SmsIrException(byte status, string message) : base(message)
        {
            Status = status;
        }
    }
}