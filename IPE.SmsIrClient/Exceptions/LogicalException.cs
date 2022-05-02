namespace IPE.SmsIrClient.Exceptions
{
    internal class LogicalException : SmsIrException
    {
        internal LogicalException(byte status, string message)
            : base(status, message)
        {
        }
    }
}