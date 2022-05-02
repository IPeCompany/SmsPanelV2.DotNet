namespace IPE.SmsIrClient.Models.Results
{
    public class SmsIrResult
    {
        public byte Status { get; }
        public string Message { get; }
    }

    public class SmsIrResult<TData> : SmsIrResult
    {
        public TData Data { get; }
    }
}