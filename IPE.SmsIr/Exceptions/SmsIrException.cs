using System;

namespace IPE.SmsIr.Exceptions
{
    public class SmsIrException : Exception
    {
        public readonly byte Status;

        public SmsIrException(byte status, string message) : base(message)
        {
            Status = status;
        }
    }
}