namespace IPE.SmsIr.Exceptions
{
    public class UnauthorizedException : SmsIrException
    {
        public UnauthorizedException(byte status, string message)
            : base(status, message)
        {
        }
    }
}