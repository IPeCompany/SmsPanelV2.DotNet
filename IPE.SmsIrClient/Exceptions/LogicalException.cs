namespace IPE.SmsIrClient.Exceptions
{
    public class LogicalException : SmsIrException
    {
        internal LogicalException(byte status, string message)
            : base(status, message)
        {
        }
    }
}