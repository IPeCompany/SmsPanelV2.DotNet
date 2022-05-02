namespace IPE.SmsIrClient.Exceptions
{
    internal class UnexpectedException : SmsIrException
    {
        internal UnexpectedException(byte status, string message)
            : base(status, message)
        {
        }
    }
}