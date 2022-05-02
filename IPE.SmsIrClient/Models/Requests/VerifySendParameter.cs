namespace IPE.SmsIrClient.Models.Requests
{
    public class VerifySendParameter
    {
        public VerifySendParameter(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }
    }
}