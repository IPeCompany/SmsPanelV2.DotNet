namespace IPE.SmsIrClient.Exceptions
{
    public class TooManyRequestException : SmsIrException
    {
        internal TooManyRequestException(byte status, string message)
            : base(status, message)
        {
        }
    }
}