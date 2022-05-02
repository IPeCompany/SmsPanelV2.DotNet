namespace IPE.SmsIrClient.Models.Requests
{
    internal class VerifySendRequest
    {
        internal VerifySendRequest(string mobile, int templateId, VerifySendParameter[] parameters)
        {
            Mobile = mobile;
            TemplateId = templateId;
            Parameters = parameters;
        }

        internal string Mobile { get; set; }

        internal int TemplateId { get; set; }

        internal VerifySendParameter[] Parameters { get; set; }
    }
}