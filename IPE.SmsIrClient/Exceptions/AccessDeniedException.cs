namespace IPE.SmsIrClient.Exceptions
{
    public class AccessDeniedException : SmsIrException
    {
        internal AccessDeniedException(byte status, string message)
            : base(status, message)
        {
        }
    }
}