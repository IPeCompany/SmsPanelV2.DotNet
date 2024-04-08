namespace IPE.SmsIrClient.Exceptions
{
    public class UnexpectedException : SmsIrException
    {
        internal UnexpectedException(byte status, string message)
            : base(status, message)
        {
        }
    }
}