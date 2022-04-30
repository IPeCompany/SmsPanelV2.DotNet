namespace IPE.SmsIr.Exceptions
{
    public class TooManyRequestException : SmsIrException
    {
        public TooManyRequestException(byte status, string message)
            : base(status, message)
        {
        }
    }
}