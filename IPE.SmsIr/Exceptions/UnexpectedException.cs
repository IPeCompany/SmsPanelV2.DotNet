namespace IPE.SmsIr.Exceptions
{
    internal class UnexpectedException : SmsIrException
    {
        internal UnexpectedException(byte status, string message)
            : base(status, message)
        {
        }
    }
}