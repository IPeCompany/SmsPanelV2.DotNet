namespace IPE.SmsIr.Exceptions
{
    public class UnexpectedException : SmsIrException
    {
        public UnexpectedException(byte status, string message)
            : base(status, message)
        {
        }
    }
}