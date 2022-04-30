namespace IPE.SmsIr.Exceptions
{
    public class LogicalException : SmsIrException
    {
        public LogicalException(byte status, string message)
            : base(status, message)
        {
        }
    }
}