namespace IPE.SmsIrClient.Exceptions
{
    public class UnauthorizedException : SmsIrException
    {
        internal UnauthorizedException(byte status, string message)
            : base(status, message)
        {
        }
    }
}