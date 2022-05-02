namespace IPE.SmsIrClient.Models.Requests
{
    internal class VerifySendRequest
    {
        public VerifySendRequest(string mobile, int templateId, VerifySendParameter[] parameters)
        {
            Mobile = mobile;
            TemplateId = templateId;
            Parameters = parameters;
        }

        public string Mobile { get; set; }

        public int TemplateId { get; set; }

        public VerifySendParameter[] Parameters { get; set; }
    }
}